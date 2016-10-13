using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Recipe_08_13
{
    public partial class Window1 : Window
    {
        private BackgroundWorker worker;

        public Window1()
        {
            InitializeComponent();

            // Create a Background Worker
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            // Enable support for cancellation
            worker.WorkerSupportsCancellation = true;

            // Attach the event handlers
            worker.DoWork += 
                new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += 
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += 
                worker_ProgressChanged;
        }

        private void button_Click(
            object sender, RoutedEventArgs e)
        {
            if(!worker.IsBusy)
            {
                this.Cursor = Cursors.Wait;

                // Start the Background Worker
                worker.RunWorkerAsync();
                button.Content = "Cancel";
            }
            else
            {
                // Cancel the Background Worker
                worker.CancelAsync();
            }
        }

        private void worker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

            if(e.Cancelled)
            {
                // The user canceled the operation
                MessageBox.Show("Operation was canceled");
            }
            else if(e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }

            button.Content = "Start";
        }

        private void worker_DoWork(
            object sender, DoWorkEventArgs e)
        {
            for(int i = 1; i <= 100; i++)
            {
                // Check if the BackgroundWorker
                // has been cancelled
                if(worker.CancellationPending)
                {
                    // Set the Cancel property
                    e.Cancel = true;
                    return;
                }

                // Simulate some processing by sleeping
                Thread.Sleep(100);
                worker.ReportProgress(i);
            }
        }

        private void worker_ProgressChanged(
            object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}