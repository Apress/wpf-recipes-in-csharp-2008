using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Xps;

namespace Recipe_07_06
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public FixedDocument GetFixedDocument()
        {
            // Create a FixedDocument
            FixedDocument fixedDocument = new FixedDocument();
            //Set the size of each page to be A4.
            Size a4PageSize = new Size(8.5 * 96, 11 * 96);
            fixedDocument.DocumentPaginator.PageSize = a4PageSize;

            //Add 5 pages to the document.
            for (int i = 1; i < 6; i++)
            {
                PageContent pageContent = new PageContent();
                fixedDocument.Pages.Add(pageContent);

                FixedPage fixedPage = new FixedPage();
                //Create a TextBlock
                TextBlock textBlock = new TextBlock();
                textBlock.Margin = new Thickness(10, 10, 0, 0);
                textBlock.Text = string.Format("Page {0}", i);
                textBlock.FontSize = 24;
                //Add the TextBlock to the page.
                fixedPage.Children.Add(textBlock);
                //Add the page to the page's content.
                ((IAddChild)pageContent).AddChild(fixedPage);
            }

            return fixedDocument;
        }

        public FlowDocument GetFlowDocument()
        {
            //Programitcally create a FlowDocument
            FlowDocument flowDocument = new FlowDocument();

            //Create a new paragraph to add to the document.
            Paragraph paragraph = new Paragraph();

            //Add some text to the paragraph.
            paragraph.Inlines.Add("This is the printed document.");

            //Add the paragraph to the document.
            flowDocument.Blocks.Add(paragraph);

            //Create a new figure and add an Ellipse to it.
            Figure figure = new Figure();
            paragraph = new Paragraph();
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 50;
            ellipse.Height = 50;
            ellipse.Fill = Brushes.Red;
            ellipse.StrokeThickness = 2;
            ellipse.Stroke = Brushes.Black;
            paragraph.Inlines.Add(ellipse);

            //Add the figure to a paragraph.
            figure.Blocks.Add(paragraph);

            //Insert the figure into a new paragraph.
            flowDocument.Blocks.Add(new Paragraph(figure));

            //Add a final paragraph
            paragraph = new Paragraph();
            paragraph.Inlines.Add("This text is not intended to be read.");

            flowDocument.Blocks.Add(paragraph);

            return flowDocument;

        }

        //Obtain a reference to a PrintQueue using a PrintDialog.
        public PrintQueue GetPrintQueue()
        {
            PrintDialog printDialog = new PrintDialog();

            bool? result = printDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                return printDialog.PrintQueue;
            }

            return null;
        }

        //Prints a FlowDocument
        public void PrintFlowDocument(PrintQueue printQueue)
        {
            FlowDocument flowDocument = GetFlowDocument();

            DocumentPaginator documentPaginator =
                ((IDocumentPaginatorSource)flowDocument).DocumentPaginator;

            XpsDocumentWriter writer =
                PrintQueue.CreateXpsDocumentWriter(printQueue);

            writer.Write(documentPaginator);
        }

        //Prints a FixedDocument
        public void PrintFixedDocument(PrintQueue printQueue)
        {
            FixedDocument fixedDocument = GetFixedDocument();

            XpsDocumentWriter writer =
                PrintQueue.CreateXpsDocumentWriter(printQueue);

            writer.Write(fixedDocument);
        }

        //Event handler for the click event of the "Print FixedDocument" button.
        private void btnPrintFixedDocument_Click(object sender, RoutedEventArgs e)
        {
            PrintFixedDocument(GetPrintQueue());
        }

        //Event handler for the click event of the "Print FlowDocument" button.
        private void btnPrintFlowDocument_Click(object sender, RoutedEventArgs e)
        {
            PrintFlowDocument(GetPrintQueue());
        }
    }
}
