using System.IO;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace Recipe_07_08
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

        //Creates a FixedDocument and places it in the document viewer.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dvDocumentViewer.Document = CreateMultiPageFixedDocument();
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

        //Handles the click event of the save button defined in markup.
        private void btnSaveDocument_Click(object sender, RoutedEventArgs e)
        {
            //Show a save dialog and get a file path.
            string filePath = ShowSaveDialog();

            //If we didn't get a path, don't try to save.
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            //Save the document to disk to the given file path.
            SaveDocument(filePath, dvDocumentViewer.Document as FixedDocument);
        }

        //Present the user with a save dialog and return a path to a file.
        private string ShowSaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XPS Files | *.xps";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.DefaultExt = ".xps";

            if (saveFileDialog.ShowDialog(this) == true)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        //Save the document to disk to the given file path.
        private void SaveDocument(string fileName, FixedDocument document)
        {
            //Delete any existing file.
            File.Delete(fileName);

            //Create a new XpsDocument at the given location.
            XpsDocument xpsDocument =
                new XpsDocument(fileName, FileAccess.ReadWrite, 
                                CompressionOption.NotCompressed);

            //Create a new XpsDocumentWriter for the XpsDocument object.
            XpsDocumentWriter xdw = XpsDocument.CreateXpsDocumentWriter(xpsDocument);

            //Write the document to the Xps file.
            xdw.Write(document);

            //Close down the saved document.
            xpsDocument.Close();            
        }
    }
}
