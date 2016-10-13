using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;    

namespace Recipe_03_06
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private String currentFileName = String.Empty;

        public Window1()
        {
            InitializeComponent();
        }

        // Handles the Open Button Click event
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            // Use a standard OpenFileDialog to allow the user to
            // select the file to open.
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = currentFileName;
            dialog.Filter = "XAML Files (*.xaml)|*.xaml";

            // Display the OpenFileDialog and read if the user
            // provides a file name.
            if (dialog.ShowDialog() == true)
            {
                // Remember the new file name.
                currentFileName = dialog.FileName;

                {
                    using (FileStream stream = File.Open(currentFileName, 
                        FileMode.Open))
                    {
                        // TODO: Need logic to handle incorrect file format errors.
                        FlowDocument doc = XamlReader.Load(stream) as FlowDocument;

                        if (doc == null)
                        {
                            MessageBox.Show("Could not load document.", Title);
                        }
                        else
                        {
                            rtbTextBox1.Document = doc;
                        }
                    }
                }
            }
        }

        // Handles the New Button Click event
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            // Create a totally new FlowDocument for the RichTextBox.
            rtbTextBox1.Document = new FlowDocument();

            currentFileName = String.Empty;
        }

        // Handles the Save Button Click event
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Use a standard SaveFileDialog to allow the user to
            // select the file to save.
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = currentFileName;
            dialog.Filter = "XAML Files (*.xaml)|*.xaml";

            // Display the SaveFileDialog and save if the user
            // provides a file name.
            if (dialog.ShowDialog() == true)
            {
                // Remember the new file name.
                currentFileName = dialog.FileName;

                using (FileStream stream = File.Open(currentFileName, 
                    FileMode.Create))
                {
                    XamlWriter.Save(rtbTextBox1.Document, stream);
                }
            }
        }
    }
}
