using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Recipe_08_14
{
    public partial class Window1 : Window
    {
        private BackgroundWorker worker;

        public Window1()
        {
            InitializeComponent();

            // Create a Background Worker
            worker = new BackgroundWorker();

            // Enable support for cancellation
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += 
                new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += 
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        private void button_Click(
            object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                this.Cursor = Cursors.Wait;

                // Set the ProgressBar's IsInderterminate
                // property to true to start the progress indicator 
                progressBar.IsIndeterminate = true;
                button.Content = "Cancel";

                // Start the Background Worker
                worker.RunWorkerAsync();
            }
            else
            {
                worker.CancelAsync();
            }
        }

        private void worker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }

            button.Content = "Start";

            // Reset the ProgressBar's IsInderterminate
            // property to false to stop the progress indicator 
            progressBar.IsIndeterminate = false;
        }

        private void worker_DoWork(
            object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 500; i++)
            {
                if (worker.CancellationPending)
                    break;

                Thread.Sleep(50);
            }
        }
    }
}