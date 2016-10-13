using System;
using System.Diagnostics;
using System.Windows;

namespace Recipe_01_14
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

        private void btnCreateNewInstance_Click(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            
            proc.StartInfo.FileName = 
                string.Format("{0}{1}", 
                              Environment.CurrentDirectory, 
                              "\\Recipe_01_14.exe");

            proc.StartInfo.Arguments = tbxArgs.Text;
            
            proc.Start();
        }
    }
}
