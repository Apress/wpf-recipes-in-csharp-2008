using System;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Xps;

namespace Recipe_07_07
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            dvDocumentViewer.Document = CreateMultiPageFixedDocument();
        }

        //Creates a FixedDocument with lots of pages.
        public FixedDocument CreateMultiPageFixedDocument()
        {
            FixedDocument fixedDocument = new FixedDocument();
            fixedDocument.DocumentPaginator.PageSize = new Size(96 * 8.5, 96 * 11);

            //Create a large number of pages so we can see the progress
            //bar and cancel button in action.
            for (int i = 0; i < 1000; i++)
            {
                PageContent pageContent = new PageContent();
                fixedDocument.Pages.Add(pageContent);
                FixedPage fixedPage = new FixedPage();

                //Add a canvas with a TextBlock and a Rectangle as children.
                Canvas canvas = new Canvas();
                fixedPage.Children.Add(canvas);

                TextBlock textBlock = new TextBlock();
                
                textBlock.Text = 
                    string.Format("Page {0} / {1}\n\nThis Is Page {0}.", 
                                  i + 1, 1000);

                textBlock.FontSize = 24;
                canvas.Children.Add(textBlock);

                Rectangle rect = new Rectangle();
                rect.Width = 200;
                rect.Height = 200;
                rect.Fill = 
                    new SolidColorBrush(Color.FromArgb(200, 20, 50, 200));
                canvas.Children.Add(rect);
                
                ((IAddChild)pageContent).AddChild(fixedPage);
            }

            return fixedDocument;
        }

        //Present the user with a PrintDialog and use it to
        //obtain a reference to a PrintQueue.
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

        //Keep a reference to the xps document writer we use.
        private XpsDocumentWriter xpsDocumentWriter;

        public void PrintDocumentAsync(FixedDocument fixedDocument)
        {
            //Get a hold of a PrintQueue.
            PrintQueue printQueue = GetPrintQueue();

            //Create a document writer to print to.
            xpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);

            //We want to know when the printing progress has changed so
            //we can update the UI.
            xpsDocumentWriter.WritingProgressChanged += 
                PrintAsync_WritingProgressChanged;

            //We also want to know when the print job has finished, allowing
            //us to check for any problems.
            xpsDocumentWriter.WritingCompleted += PrintAsync_Completed;

            StartLongPrintingOperation(fixedDocument.Pages.Count);

            //Print the FixedDocument asynchronously.
            xpsDocumentWriter.WriteAsync(fixedDocument);
        }

        private void PrintAsync_WritingProgressChanged(object sender, 
            WritingProgressChangedEventArgs e)
        {
            //Another page of the document has been printed. Update the UI.
            pbPrintProgress.Value = e.Number;
        }

        private void PrintAsync_Completed(object sender, 
            WritingCompletedEventArgs e)
        {
            string message;
            MessageBoxImage messageBoxImage;

            //Check to see if there was a problem with the printing.
            if (e.Error != null)
            {
                messageBoxImage = MessageBoxImage.Error;
                message =
                    string.Format("An error occurred whilst printing.\n\n{0}",
                                  e.Error.Message);
            }
            else if (e.Cancelled)
            {
                messageBoxImage = MessageBoxImage.Stop;
                message = "Printing was cancelled by the user.";
            }
            else
            {
                messageBoxImage = MessageBoxImage.Information;
                message = "Printing completed successfully.";
            }

            MessageBox.Show(message, "Recipe_07_07", 
                            MessageBoxButton.OK, messageBoxImage);

            StopLongPrintingOperation();
        }

        private void StartLongPrintingOperation(int pages)
        {
            pbPrintProgress.Value = 0;
            pbPrintProgress.Maximum = pages;
            
            spProgressMask.Visibility = Visibility.Visible;
        }

        private void StopLongPrintingOperation()
        {
            spProgressMask.Visibility = Visibility.Collapsed;
        }

        private void DocumentViewer_PrintDocument(object sender, EventArgs e)
        {
            PrintDocumentAsync(CreateMultiPageFixedDocument());
        }

        private void btnCancelPrint_Click(object sender, RoutedEventArgs e)
        {
            //The user has pressed the cancel button.
            //First ensure we have a valid XpsDocumentWriter.
            if (xpsDocumentWriter != null)
            {
                //Cancel the job.
                xpsDocumentWriter.CancelAsync();
            }
        }
    }
}
