using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Win32;

namespace Recipe_04_02
{
    /// <summary>
    /// ContentyProperty attribute 
    /// </summary>
    [ContentProperty("FileName")]
    public partial class FileInputControl : UserControl
    {
        public FileInputControl()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(
            object sender, 
            System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == true)
            {
                this.FileName = dlg.FileName;
            }
        }

        public string FileName
        {
            get
            {
                return txtBox.Text;
            }
            set
            {
                txtBox.Text = value;
            }
        }
    }
}