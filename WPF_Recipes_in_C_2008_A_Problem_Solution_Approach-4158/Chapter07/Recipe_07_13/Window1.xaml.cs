using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Xps.Packaging;

namespace Recipe_07_13
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

        public Window1()
        {
            InitializeComponent();
        }

        //When the Window is loaded, we want to get hold of some
        //test document to try out the sticky notes on, then
        //start up the annotation services which make it possible.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load in our sample FixedDocument
            LoadFixedDocument();
            //Create a new FlowDocument
            fdv.Document = CreateFlowDocument();

            //Start the annotation services
            StartFixedDocumentAnnotations();
            StartFlowDocumentAnnotations();
        }

        //Handles the user clicking the 'Add Comment' context menu item 
        //on the document viewer in the FixedDocument tab.
        private void Xdv_AddComment_Click(object sender, RoutedEventArgs e)
        {
            //Get the current user's name and 
            //use as the comment's author
            string userName = System.Environment.UserName;

            //The AnnotationHelper.CreateTextStickyNoteForSelection method
            //will throw an exception if no text is selected.
            try
            {
                AnnotationHelper.CreateTextStickyNoteForSelection(
                    fixedAnnotationService, userName);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please select some text to annotate.");
            }
        }

        //Handles the user clicking the 'Add Comment' context menu item 
        //on the document viewer in the FlowDocument tab.
        private void Fdv_AddComment_Click(object sender, RoutedEventArgs e)
        {
            //Get the current user's name as the author
            string userName = System.Environment.UserName;

            //The AnnotationHelper.CreateTextStickyNoteForSelection method
            //will throw an exception if no text is selected.
            try
            {
                AnnotationHelper.CreateTextStickyNoteForSelection(
                    flowAnnotationService, userName);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Please select some text to annotate.");
            }
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

        //Create a simple FlowDocument that can be used for testing out
        //sticky notes.
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

            XpsDocument xpsDocument = null;

            try
            {
                //Attempts to open the specified xps document with
                //read and write permission.
                xpsDocument = new XpsDocument(documentPath, FileAccess.ReadWrite);
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
            xdv.Document = fixedDocumentSequence;
        }
    }
}