using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps.Packaging;
using System.Xml;
using Microsoft.Win32;

namespace Recipe_07_12
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

        //Handles the click event of the 'Open...' button for the fixed document viewer.
        private void btnOpenFixedDoc_Click(object sender, RoutedEventArgs e)
        {
            string filePath = GetFileName("XPS Document (*.xps)|*.xps");

            if (string.IsNullOrEmpty(filePath))
            {
                ShowFileOpenError(filePath);
                return;
            }

            IDocumentPaginatorSource documentSource = OpenFixedDocument(filePath);

            if (documentSource == null)
            {
                ShowFileOpenError(filePath);
            }

            dvDocumentViewer.Document = documentSource;
        }

        //Handles the click event of the 'Open...' button for the flow document viewer.
        private void btnOpenFlowDoc_Click(object sender, RoutedEventArgs e)
        {
            string filePath = GetFileName("XAML Document (*.xaml)|*.xaml");

            if (string.IsNullOrEmpty(filePath))
            {
                ShowFileOpenError(filePath);
                return;
            }

            FlowDocument flowDocument = OpenFlowDocument(filePath);

            if (flowDocument == null)
            {
                ShowFileOpenError(filePath);
                return;
            }

            fdv.Document = flowDocument;
        }

        //Presents the user with an open file dialog and returns
        //the path to any file they select to open.
        private string GetFileName(string filter)
        {
            //First get the file to be opened
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }

            return null;
        }

        private IDocumentPaginatorSource OpenFixedDocument(string fileName)
        {
            try
            {
                //Load the XpsDocument into memory.
                XpsDocument document = new XpsDocument(fileName, FileAccess.Read);

                if (document == null)
                {
                    return null;
                }

                //Get an IDocumentPaginatorSource for the document.
                return document.GetFixedDocumentSequence();
            }
            catch (Exception)
            {
                return null;
            }
        }

        private FlowDocument OpenFlowDocument(string fileName)
        {
            Stream file = null;
            TextReader reader = null;
            XmlTextReader xmlReader = null;

            try
            {
                //Load the file into memory.
                file = File.OpenRead(fileName);
                reader = new StreamReader(file);
                //Create a XmlTextReader to use with the XamlReader below.
                xmlReader = new XmlTextReader(reader);
                //Parse the XAML file and load the FlowDocument.
                return XamlReader.Load(xmlReader) as FlowDocument;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (file != null)
                    file.Dispose();

                if (reader != null)
                    reader.Dispose();

                if (xmlReader != null)
                    xmlReader.Close();
            }                
        }

        //Display a message if the file cannot be opened.
        private void ShowFileOpenError(string filePath)
        {
            string msg = string.Format("Unable to open " + filePath);
            MessageBox.Show(msg, "Recipe 7-12", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
    }
}
