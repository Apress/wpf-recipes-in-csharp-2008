using System;
using System.IO;
using System.Printing;
using System.Reflection;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace Recipe_07_16
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //Fields to handle our Annotation specifics.
        private AnnotationService fixedAnnotationService;
        private AnnotationStore fixedAnntationStore;
        private Stream fixedAnnotationBuffer;

        private XpsDocument xpsDocument;
        private FixedDocumentSequence fixedDocumentSequence;

        public Window1()
        {
            InitializeComponent();
            //Load in our fixed document.
            LoadFixedDocument();
            //Fire up the annotation service...
            StartFixedDocumentAnnotations();
        }
               
        private void  DocumentViewer_AddComment(object sender, RoutedEventArgs e)
        {
            //Get the current user's name as the author
            string userName = System.Environment.UserName;

            //The AnnotationHelper.CreateTextStickyNoteForSelection method
            //will throw an exception if no text is selected.
            try
            {
                AnnotationHelper.CreateTextStickyNoteForSelection(fixedAnnotationService, userName);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please select some text to annotate.");
            }
        }


        //An XPS document is loaded and displayed in the document viewer,
        //ready for annotating.
        private void LoadFixedDocument()
        {
            string documentPath = 
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) 
                + "\\SampleDocument\\FixedDocument.xps";
            
            //Create a URI for the file path.
            Uri documentUri = new Uri(documentPath, UriKind.Absolute);

            xpsDocument = null;

            try
            {
                //Attempts to open the specified xps document with
                //read and write permission.
                xpsDocument = new XpsDocument(documentPath, 
                    FileAccess.ReadWrite);
            }
            catch (Exception)
            {
                //You may want to handle any errors that occur during
                //the loading of the XPS document. For example a
                //UnauthorizedAccessException will be thrown if the
                //file is marked as read-only.
            }

            //If the document is null, it's not a valid XPS document.
            if (xpsDocument == null)
                return; //Handle as required.

            //Get the FixedDocumentSequence of the loaded document.
            fixedDocumentSequence
                = xpsDocument.GetFixedDocumentSequence();

            //If the document's FixedDocumentSequence is not found,
            //the document is corrupt.
            if (fixedDocumentSequence == null)
                return; //Handle as required.

            //Load the document's FixedDocumentSequence into 
            //the DocumentViewer control.
            dvDocumentViewer.Document = fixedDocumentSequence;
        }   

        private void StartFixedDocumentAnnotations()
        {
            //If there is no AnnotationService yet, create one.
            if (fixedAnnotationService == null)
                fixedAnnotationService 
                    = new AnnotationService(dvDocumentViewer);

            //If the AnnotationService is currently enabled, disable it
            //as you'll need to re-enable it with a new store object.
            if (fixedAnnotationService.IsEnabled)
                fixedAnnotationService.Disable();

            //Open a memory stream for storing annotations.
            fixedAnnotationBuffer = new MemoryStream();

            //Create a new AnnotationStore using the above stream.
            fixedAnntationStore = new XmlStreamStore(fixedAnnotationBuffer);

            //Enable the AnnotationService using the new store object.
            fixedAnnotationService.Enable(fixedAnntationStore);
        }

        //Present the user with a PrintDialog, allowing them to
        //select and configure a printer.
        public PrintQueue ShowPrintDialog()
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
                return printDialog.PrintQueue;

            return null;
        }

        //Handles the click of the print button in the document 
        //viewer, overriding the default behavior.
        private void DocumentViewer_PrintDocument(object sender, RoutedEventArgs e)
        {
            //Get a print queue
            PrintQueue printQueue = ShowPrintDialog();

            if (printQueue == null)
                return;

            try
            {
                //Create a new XPS writer using the chosen print queue.
                XpsDocumentWriter writer
                    = PrintQueue.CreateXpsDocumentWriter(printQueue);

                //We need to use a copy of the document's fixed document
                //sequence when creating the AnnotationDocumentPaginator.
                FixedDocumentSequence fds 
                    = xpsDocument.GetFixedDocumentSequence();
                
                //You now need to create a document paginator for any 
                //annotations in the document.
                AnnotationDocumentPaginator adp =
                    new AnnotationDocumentPaginator(fds.DocumentPaginator,
                        fixedAnnotationService.Store);

                //Write out the document, with annotations using the annotation
                //document paginator.
                writer.Write(adp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

