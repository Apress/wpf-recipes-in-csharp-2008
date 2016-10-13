using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;
using Microsoft.Win32;

namespace Recipe_07_10
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

        /// <summary>
        /// This method handles the click event on the only button
        /// in the application's main window. The user is presented
        /// with a dialog in which a file path is chosen. A call
        /// to the save method is then made.
        /// </summary>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string filePath = ShowSaveDialog();

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            SaveFile(filePath, fdrViewer.Document);
        }

        /// <summary>
        /// Creates and displays a SaveFileDialog allowing the user to
        /// select a location to save the document to.
        /// </summary>
        /// <returns>
        /// When the save dialog is closed via the 'Ok' button, the
        /// method returns the chosen file path, otherwise it returns
        /// null.
        /// </returns>
        private string ShowSaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XAML Files | *.xaml";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.DefaultExt = ".xaml";

            if (saveFileDialog.ShowDialog(this) == true)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        /// <summary>
        /// Saves a FixedDocument to a .xaml file at the target location.
        /// </summary>
        /// <param name="fileName">
        /// The target location for the document.
        /// </param>
        /// <param name="documentSource">
        /// An IDocumentPaginatorSource for the FixedDocument to be saved 
        /// to disk.
        /// </param>
        private void SaveFile(string fileName,
                              IDocumentPaginatorSource documentSource)
        {
            XmlTextWriter xmlWriter = null;
            TextWriter writer = null;
            Stream file = null;

            try
            {
                file = File.Create(fileName);
                writer = new StreamWriter(file);

                xmlWriter = new XmlTextWriter(writer);

                // Set serialization mode
                XamlDesignerSerializationManager xamlManager =
                    new XamlDesignerSerializationManager(xmlWriter);

                // Serialize
                XamlWriter.Save(documentSource.DocumentPaginator.Source, xamlManager);

            }
            catch (Exception e)
            {
                string msg = string.Format("Error occurred during saving.{0}{0}{1}",
                    Environment.NewLine,
                    e.Message);

                MessageBox.Show(msg,
                                "Recipe_07_10",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }

                if (writer != null)
                {
                    writer.Close();
                }

                if (file != null)
                {
                    file.Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Programitcally create a FlowDocument
            FlowDocument flowDocument = new FlowDocument();

            //Create a new paragraph to add to the document.
            Paragraph paragraph = new Paragraph();

            //Add some text to the paragraph.
            paragraph.Inlines.Add("This is a paragraph.");
            paragraph.Inlines.Add(" This is a paragraph.");
            paragraph.Inlines.Add(" This is a paragraph.");
            paragraph.Inlines.Add(" This is a paragraph.");
            paragraph.Inlines.Add(" This is a paragraph.");
            paragraph.Inlines.Add(" This is a paragraph.");
            paragraph.Inlines.Add(" This is a paragraph.");
            paragraph.Inlines.Add(" This is a paragraph.");

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
            paragraph.Inlines.Add("This is another paragraph.");
            paragraph.Inlines.Add(" This is another paragraph.");
            paragraph.Inlines.Add(" This is another paragraph.");
            paragraph.Inlines.Add(" This is another paragraph.");
            paragraph.Inlines.Add(" This is another paragraph.");
            paragraph.Inlines.Add(" This is another paragraph.");
            paragraph.Inlines.Add(" This is another paragraph.");
            paragraph.Inlines.Add(" This is another paragraph.");

            flowDocument.Blocks.Add(paragraph);

            //Now set the content of the document reader to the
            //new FlowDocument
            fdrViewer.Document = flowDocument;
        }
    }
}
