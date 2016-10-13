using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Recipe_08_09
{
    public partial class Window1 : Window
    {
        private readonly BackgroundWorker worker;

        public Window1()
        {
            InitializeComponent();

            // Retrieve a reference to the
            // BackgroundWorker declared in the XAML
            worker = this.FindResource("backgroundWorker") 
                     as BackgroundWorker;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(!worker.IsBusy)
            {
                this.Cursor = Cursors.Wait;

                worker.RunWorkerAsync();
                button.Content = "Cancel";
            }
            else
            {
                worker.CancelAsync();
            }
        }

        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for(int i = 1; i <= 100; i++)
            {
                if(worker.CancellationPending)
                    break;

                Thread.Sleep(100);
                worker.ReportProgress(i);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

            if(e.Error != null)
                MessageBox.Show(e.Error.Message);

            button.Content = "Start";
        }

        private void BackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}