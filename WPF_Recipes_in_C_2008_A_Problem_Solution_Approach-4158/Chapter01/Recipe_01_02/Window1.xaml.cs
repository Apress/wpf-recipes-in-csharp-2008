using System;
using System.Windows;
using System.ComponentModel;

namespace Recipe_01_02
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

        private void btnThrowHandledException_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThrowUnhandledException_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnThrowUnhandledExceptionFromThread_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += delegate { throw new NotImplementedException(); };              

            backgroundWorker.RunWorkerAsync();
        }
    }
}
