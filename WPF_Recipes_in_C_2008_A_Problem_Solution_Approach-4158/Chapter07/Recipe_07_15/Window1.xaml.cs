using System;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Xps;
using System.Printing;

namespace Recipe_07_15
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private AnnotationService fixedAnnotationService;
        private AnnotationStore fixedAnntationStore;
        private Stream fixedAnnotationBuffer;
        private Uri documentUri;
        private Package xpsPackage;
        private XpsDocument xpsDocument;

        private bool hasOpenDocument;

        private const string fixedDocumentSequenceContentType =
            "application/vnd.ms-package.xps-fixeddocumentsequence+xml";

        private const string annotRelsType =
            "http://schemas.microsoft.com/xps/2005/06/annotations";

        private const string annotContentType =
            "application/vnd.ms-package.annotations+xml";

        public Window1()
        {
            InitializeComponent();

            hasOpenDocument = false;
        }

        //Handles the Click event raised by the 
        //'Open' button, defined in markup.
        private void btnOpenXps_Click(object sender, RoutedEventArgs e)
        {
            CloseFixedDocument();

            LoadFixedDocument();
        }
                
        //Handles the Click event raised by the
        //'Save' button, defined in markup.
        private void btnSaveXps_Click(object sender, RoutedEventArgs e)
        {
            SaveAnnotations();
        }

        //Handles the Closed event, raised by the window 
        //defined  in markup, clearing up.
        private void Window_Closed(object sender, EventArgs e)
        {
            StopFixedDocumentAnnotations();
        }

        //Closes an open document and tidies up.
        private void CloseFixedDocument()
        {
            if (hasOpenDocument)
            {
                StopFixedDocumentAnnotations();

                PackageStore.RemovePackage(documentUri);

                xpsDocument.Close();
                xpsDocument = null;
                
                xpsPackage.Close();
                xpsPackage = null;
            }
        }

        //Presents the user with an OpenFileDialog, used to get a path
        //to the XPS document they want to open. If this succeeds, 
        //the XPS document is loaded and displayed in the document viewer,
        //ready for annotating.
        private void LoadFixedDocument()
        {
            //Get a path to the file to be opened.
            string fileName = GetDocumentPath();
            //If we didn't get a valid file path, we're done.
            //You might want to log an error here.
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            
            //Create a URI for the file path.
            documentUri = new Uri(fileName, UriKind.Absolute);

            try
            {
                //Attempts to open the specified xps document with
                //read and write permission.
                xpsDocument = new XpsDocument(fileName, FileAccess.ReadWrite);
            }
            catch (Exception)
            {
                //You may want to handle any errors that occur during
                //the loading of the XPS document. For example a
                //UnauthorizedAccessException will be thrown if the
                //file is marked as read-only.
            }

            //Get the document's Package from the PackageStore.
            xpsPackage = PackageStore.GetPackage(documentUri);

            //If either the package or document are null, the 
            //document is not valid.
            if ((xpsPackage == null) || (xpsDocument == null))
            {
                //You may want to log an error here.
                return;
            }

            //Get the FixedDocumentSequence of the loaded document.
            FixedDocumentSequence fixedDocumentSequence
                = xpsDocument.GetFixedDocumentSequence();

            //If the document's FixedDocumentSequence is not found,
            //the document is corrupt.
            if (fixedDocumentSequence == null)
            {
                //Handle as required.
                return;
            }

            //Load the document's FixedDocumentSequence into 
            //the DocumentViewer control.
            dvViewer.Document = fixedDocumentSequence;

            //Enable user annotations on the document.
            StartFixedDocumentAnnotations();

            hasOpenDocument = true;
        }

        //Present the user with an OpenFileDialog, allowing
        //them to select a file to open. If a file is selected,
        //return the path to the file, otherwise return an empty
        //string.
        private string GetDocumentPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XPS Document | *.xps";
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            openFileDialog.InitialDirectory = Path.GetFullPath(Assembly.GetExecutingAssembly().Location);

            string result = string.Empty;

            if (openFileDialog.ShowDialog(this) == true)
            {
                result = openFileDialog.FileName;
            }

            return result;
        }

        //Saves the document's annotations by flushing their buffers.
        //The package is also flushed so that the changes are persisted
        //to disk.
        private void SaveAnnotations()
        {
            //Check that we have a valid fixed annotation service.
            if (fixedAnnotationService != null
                && fixedAnnotationService.IsEnabled)
            {
                fixedAnnotationService.Store.Flush();
                fixedAnnotationBuffer.Flush();
            }

            if (xpsPackage != null)
            {
                xpsPackage.Flush();
            }
        }

        private void StartFixedDocumentAnnotations()
        {
            //If there is no AnnotationService yet, create one.
            if (fixedAnnotationService == null)
            {
                fixedAnnotationService = new AnnotationService(dvViewer);
            }

            //If the AnnotationService is currently enabled, disable it
            //as you'll need to re-enable it with a new store object.
            if (fixedAnnotationService.IsEnabled)
            {
                fixedAnnotationService.Disable();
            }

            //Open a stream to the file for storing annotations.
            fixedAnnotationBuffer = 
                GetAnnotationPart(GetFixedDocumentSequenceUri()).GetStream();

            //Create a new AnnotationStore using the file stream.
            fixedAnntationStore = new XmlStreamStore(fixedAnnotationBuffer);

            //Enable the AnnotationService using the new store object.
            fixedAnnotationService.Enable(fixedAnntationStore);
        }

        //When closing the application, or just the document it is
        //important to close down the existing annotation service,
        //releasing any resources. Note that the annotation service
        //is stopped without saving changes.
        public void StopFixedDocumentAnnotations()
        {
            //If the AnnotationStore is active, flush and close it.
            if ((fixedAnnotationService != null) && fixedAnnotationService.IsEnabled)
            {
                fixedAnnotationService.Store.Dispose();                
                fixedAnnotationBuffer.Close();
            }

            //If the AnnotationService is active, shut it down.
            if (fixedAnnotationService != null)
            {
                if (fixedAnnotationService.IsEnabled)
                {
                    fixedAnnotationService.Disable();
                }

                fixedAnnotationService = null;
            }
        }

        //Searches the parts of a document, looking for the        
        //FixedDocumentSequence part. If the part is found,
        //its URI is returned, otherwise null is returned.
        private Uri GetFixedDocumentSequenceUri()
        {
            Uri result = null;
            PackagePart packagePart;
            
            //Get the FixedDocumentSequence part from the Package.
            packagePart = xpsPackage.GetParts().Single<PackagePart>(
                part => 
                    part.ContentType == fixedDocumentSequenceContentType);

            //If we found the part, note its URI.
            if (packagePart != null)
            {
                result = packagePart.Uri;
            }

            return result;            
        }

        private PackagePart GetAnnotationPart(Uri uri)
        {
            Package package = PackageStore.GetPackage(documentUri);

            if (package == null)
            {
                return null;
            }

            // Get the FixedDocumentSequence part from the package.
            PackagePart fdsPart = package.GetPart(uri);

            // Search through all the document relationships to find the
            // annotations relationship part (or null, of there is none).
            PackageRelationship annotRel = null;

            annotRel 
                = fdsPart.GetRelationships().FirstOrDefault<PackageRelationship>(
                    pr => pr.RelationshipType == annotRelsType);
                                     
            PackagePart annotPart;

            //If annotations relationship does not exist, create a new
            //annotations part, if required, and a relationship for it.
            if (annotRel == null)
            {
                Uri annotationUri =
                    PackUriHelper.CreatePartUri(new Uri("annotations.xml",
                                                UriKind.Relative));

                if (package.PartExists(annotationUri))
                {
                    annotPart = package.GetPart(annotationUri);
                }
                else
                {
                    //Create a new Annotations part in the document.
                    annotPart = package.CreatePart(annotationUri, annotContentType);
                }

                //Create a new relationship that points to the Annotations part.
                fdsPart.CreateRelationship(annotPart.Uri,
                                           TargetMode.Internal,
                                           annotRelsType);
            }            
            else
            {
                //If an annotations relationship exists,
                //get the annotations part that it references.

                //Get the Annotations part specified by the relationship.
                annotPart = package.GetPart(annotRel.TargetUri);

                if (annotPart == null)
                {
                    //The annotations part pointed to by the annotation
                    //relationship Uri is not present. Handle as required.
                    return null;
                }
            }

            return annotPart;
        }
    }
}
