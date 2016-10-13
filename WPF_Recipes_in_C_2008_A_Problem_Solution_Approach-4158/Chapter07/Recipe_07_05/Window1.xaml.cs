using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;

namespace Recipe_07_05
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private PrintQueue printQueue;
        private PrintTicket printTicket;

        public Window1()
        {
            InitializeComponent();
        }

        //When the Window loads, set the initial control states.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gbStage1.IsEnabled = true;
            gbStage2.IsEnabled = false;
            gbStage3.IsEnabled = false;
        }

        private void btnSelectPrinter_Click(object sender, RoutedEventArgs e)
        {
            //Set the state of the options controls
            printQueue = GetPrintQueue();

            if (printQueue == null)
            {
                return;
            }

            // Get default PrintTicket from printer
            printTicket = printQueue.UserPrintTicket;

            PrintCapabilities printCapabilites = printQueue.GetPrintCapabilities();

            SetControlStates(printCapabilites, printTicket);
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            SetPrintTicket(printTicket);

            XpsDocumentWriter documentWriter =
                PrintQueue.CreateXpsDocumentWriter(printQueue);

            documentWriter.Write(CreateMultiPageFixedDocument(), printTicket);

            MessageBox.Show("Document printed.",
                            "Recipe 07 05",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private PrintQueue GetPrintQueue()
        {
            // Create a Print dialog.
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() != true)
            {
                return null;
            }

            // Get the default print queue
            PrintQueue printQueue = printDialog.PrintQueue;

            return printQueue;
        }

        public FixedDocument CreateMultiPageFixedDocument()
        {
            FixedDocument fixedDocument = new FixedDocument();

            //Set the size of each page to be A4 (8.5" x 11").
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

        //Set the states of the controls defined in the markup
        //for this Window.
        private void SetControlStates(
            PrintCapabilities printCapabilities,
            PrintTicket printTicket)
        {
            gbStage1.IsEnabled = false;
            gbStage2.IsEnabled = true;
            gbStage3.IsEnabled = true;

            //Set duplexing options.            
            rbDuplexing1.IsEnabled =
                printCapabilities.DuplexingCapability.Contains(
                    Duplexing.OneSided);

            rbDuplexing1.IsChecked =
                printTicket.Duplexing == Duplexing.OneSided;

            rbDuplexing2.IsEnabled =
                printCapabilities.DuplexingCapability.Contains(
                    Duplexing.TwoSidedLongEdge);

            rbDuplexing2.IsChecked =
                printTicket.Duplexing == Duplexing.TwoSidedLongEdge;

            rbDuplexing3.IsEnabled =
                printCapabilities.DuplexingCapability.Contains(
                    Duplexing.TwoSidedShortEdge);

            rbDuplexing3.IsChecked =
                printTicket.Duplexing == Duplexing.TwoSidedShortEdge;

            //Set colation properties.
            rbCollation1.IsEnabled =
                printCapabilities.CollationCapability.Contains(
                    Collation.Collated);

            rbCollation1.IsChecked =
                printTicket.Collation == Collation.Collated;

            rbCollation2.IsEnabled =
                printCapabilities.CollationCapability.Contains(
                    Collation.Uncollated);

            rbCollation2.IsChecked =
                printTicket.Collation == Collation.Uncollated;

            //Set the orientation properties
            rbOrientation1.IsEnabled =
                printCapabilities.PageOrientationCapability.Contains(
                    PageOrientation.Landscape);

            rbOrientation1.IsChecked =
                printTicket.PageOrientation == PageOrientation.Landscape;

            rbOrientation2.IsEnabled =
                printCapabilities.PageOrientationCapability.Contains(
                    PageOrientation.Portrait);

            rbOrientation2.IsChecked =
                printTicket.PageOrientation == PageOrientation.Portrait;
        }

        private void SetPrintTicket(PrintTicket printTicket)
        {
            //Determine the Duplexing value.
            if (rbDuplexing1.IsEnabled
                && rbDuplexing2.IsChecked == true)
            {
                printTicket.Duplexing = Duplexing.OneSided;
            }
            else if (rbDuplexing2.IsEnabled
                     && rbDuplexing2.IsChecked == true)
            {
                printTicket.Duplexing = Duplexing.TwoSidedLongEdge;
            }
            else if (rbDuplexing3.IsEnabled
                     && rbDuplexing3.IsChecked == true)
            {
                printTicket.Duplexing = Duplexing.TwoSidedShortEdge;
            }

            //Determine the Collation setting.
            if (rbCollation1.IsEnabled
                && rbDuplexing2.IsChecked == true)
            {
                printTicket.Collation = Collation.Collated;
            }
            else if (rbCollation2.IsEnabled
                     && rbDuplexing2.IsChecked == true)
            {
                printTicket.Collation = Collation.Uncollated;
            }

            //Determine the Orientation value.
            if (rbOrientation1.IsEnabled
                && rbOrientation1.IsChecked == true)
            {
                printTicket.PageOrientation = PageOrientation.Landscape;
            }
            else if (rbOrientation2.IsEnabled
                     && rbOrientation2.IsChecked == true)
            {
                printTicket.PageOrientation = PageOrientation.Portrait;
            }
        }
    }
}
