using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Xps.Packaging;

namespace Recipe_07_14
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //FixedDoxument specifics
        AnnotationService fixedAnnotationService;
        AnnotationStore fixedAnntationStore;
        MemoryStream fixedAnnotationBuffer;

        //FlowDocument specifics
        AnnotationService flowAnnotationService;
        AnnotationStore flowAnntationStore;
        MemoryStream flowAnnotationBuffer;

        XpsDocument xpsDocument;

        public Window1()
        {
            InitializeComponent();
            //Fire up the annotation services.
            StartFixedDocumentAnnotations();
            StartFlowDocumentAnnotations();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Populate the two document viewers.
            LoadFixedDocument();
            fdv.Document = CreateFlowDocument();
        }

        private void StartFixedDocumentAnnotations()
        {
            //Create a new annotation service for the fixed document viewer.
            fixedAnnotationService = new AnnotationService(xdv);

            //Open a stream for our annotation store.
            fixedAnnotationBuffer = new MemoryStream();

            //Create an AnnotationStore using the stream.
            fixedAnntationStore = new XmlStreamStore(fixedAnnotationBuffer);

            //Enable the AnnotationService against the new annotation store.
            fixedAnnotationService.Enable(fixedAnntationStore);
        }

        private void StartFlowDocumentAnnotations()
        {
            //Create a new annotation service for the fixed document viewer.
            flowAnnotationService = new AnnotationService(fdv);            

            //Open a stream for our annotation store.
            flowAnnotationBuffer = new MemoryStream();

            //Create an AnnotationStore using the stream.
            flowAnntationStore = new XmlStreamStore(flowAnnotationBuffer);

            //Enable the AnnotationService against the new annotation store.
            flowAnnotationService.Enable(flowAnntationStore);
        }        

        //This method is called when the 'Add Highlight' context menu is 
        //clicked by the user on either of the two document viewer controls.
        private void DocumentViewer_AddHighlight(object sender, 
            RoutedEventArgs e)
        {            
            //Work out which document viewer we are dealing with
            //and get the appropriate store.
            string tag = ((MenuItem)sender).Tag.ToString();

            AnnotationService annotationService =
                tag == "fixed"
                ? fixedAnnotationService
                : flowAnnotationService;

            //Get the current user's name as the author
            string userName = System.Environment.UserName;

            try
            {
                //Creates a yellow highlight
                AnnotationHelper.CreateHighlightForSelection(
                    annotationService, userName, Brushes.Yellow);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please select some text to highlight.");
            }
        }

        private void DocumentViewer_ClearHighlight(object sender, RoutedEventArgs e)
        {
            //Work out which document viewer we are dealing with
            //and get the appropriate store.
            string tag = ((MenuItem)sender).Tag.ToString();

            AnnotationService annotationService =
                tag == "fixed"
                ? fixedAnnotationService
                : flowAnnotationService;

            try
            {
                //Clear the selected text of any highlights.
                AnnotationHelper.ClearHighlightsForSelection(
                    annotationService);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please select some text to clear.");
            }
        }

        //Creates a simple FlowDocument containing text which can be
        //highlighted.
        private FlowDocument CreateFlowDocument()
        {
            FlowDocument flowDocument = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            paragraph.FontSize = 12;
            paragraph.Foreground = Brushes.Black;
            paragraph.FontWeight = FontWeights.Bold;
            paragraph.Inlines.Add(new Run("This is a FlowDocument."));

            flowDocument.Blocks.Add(paragraph);

            paragraph = new Paragraph();
            paragraph.FontWeight = FontWeights.Normal;
            paragraph.Inlines.Add(new Run("This is a paragraph in the FlowDocument."));

            flowDocument.Blocks.Add(paragraph);

            return flowDocument;
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
            FixedDocumentSequence fixedDocumentSequence
                = xpsDocument.GetFixedDocumentSequence();

            //If the document's FixedDocumentSequence is not found,
            //the document is corrupt.
            if (fixedDocumentSequence == null)
                return; //Handle as required.

            //Load the document's FixedDocumentSequence into 
            //the DocumentViewer control.
            xdv.Document = fixedDocumentSequence;
        }
    }
}