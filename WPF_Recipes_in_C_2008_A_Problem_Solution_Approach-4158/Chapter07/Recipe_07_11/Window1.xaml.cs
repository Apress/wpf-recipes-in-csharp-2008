using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace Recipe_07_11
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private XpsDocumentWriter xdw = null;

        public Window1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Present the user with a save dialog, getting the path
            //to a file where the document will be saved.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".xps|*.xps";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Title = "Save to Xps Document";

            //If the user cancelled the dialog, bail.
            if (saveFileDialog.ShowDialog(this) == false)
            {
                return;
            }

            //Save the document.
            SaveDocument(saveFileDialog.FileName, 
                dvDocumentViewer.Document as FixedDocument);
        }

        private void SaveDocument(string fileName, FixedDocument document)
        {
            //Delete any existing file.
            File.Delete(fileName);

            //Create a new XpsDocument at the given location.
            XpsDocument xpsDocument =
                new XpsDocument(fileName, FileAccess.ReadWrite);

            //Create a new XpsDocumentWriter for the XpsDocument object.
            xdw = XpsDocument.CreateXpsDocumentWriter(xpsDocument);

            //We want to be notified of when the progress changes.
            xdw.WritingProgressChanged +=
                delegate(object sender, WritingProgressChangedEventArgs e)
                {   //Update the value of the progress bar.
                    pbSaveProgress.Value = e.Number;
                };

            //We want to be notified of when the operation is complete.
            xdw.WritingCompleted +=
                delegate(object sender, WritingCompletedEventArgs e)
                {
                    //We're finished with the XPS document so close it.
                    //This step is important.
                    xpsDocument.Close();

                    string msg = "Saving complete.";

                    if (e.Error != null)
                    {
                        msg =
                            string.Format("An error occurred whilst " +
                                          "saving the document.\n\n{0}",
                                          e.Error.Message);
                    }
                    else if (e.Cancelled)
                    {
                        //Delete the incomplete file.
                        File.Delete(fileName);

                        msg = 
                            string.Format("Saving cancelled by user.");
                    }

                    //Inform the user of the print operation's exit status.
                    MessageBox.Show(msg,
                                    "Recipe_07_11",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    spProgressMask.Visibility = Visibility.Collapsed;
                };

            //Show the long operation mask with the cancel button and progress bar.
            spProgressMask.Visibility = Visibility.Visible;
            pbSaveProgress.Maximum = document.Pages.Count;
            pbSaveProgress.Value = 0;

            //Write the document to the Xps file asynchronously.
            xdw.WriteAsync(document);
        }

        private void btnCancelSave_Click(object sender, RoutedEventArgs e)
        {
            //When the 'Cancel' button is clicked, we want to try and
            //stop the save process.
            if (xdw != null)
                xdw.CancelAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load the Fixed Document with a simple FixedDocument.
            //A large number of pages are generated so that the progress
            //of the printing is slow enough to be observed.
            dvDocumentViewer.Document = CreateFixedPageDocument(1000);
        }

        private FixedDocument CreateFixedPageDocument(int numberOfPages)
        {
            // Create a FixedDocument
            FixedDocument fixedDocument = new FixedDocument();
            fixedDocument.DocumentPaginator.PageSize = new Size(96 * 8.5, 96 * 11);

            for (int i = 0; i < numberOfPages; i++)
            {
                PageContent pageContent = new PageContent();
                fixedDocument.Pages.Add(pageContent);
                FixedPage fixedPage = new FixedPage();
                TextBlock textBlock = new TextBlock();
                textBlock.Text = string.Format("Page {0}", i);
                textBlock.FontSize = 24;
                fixedPage.Children.Add(textBlock);
                ((IAddChild)pageContent).AddChild(fixedPage);
            }

            return fixedDocument;
        }
    }
}
