using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Recipe_08_12
{
    public partial class Window1 : Window
    {
        private BackgroundWorker worker;

        public Window1()
        {
            InitializeComponent();

            // Create a Background Worker
            worker = new BackgroundWorker();

            // Enable progress reporting
            worker.WorkerReportsProgress = true;

            // Attach the event handlers
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += worker_ProgressChanged;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Start the Background Worker
            worker.RunWorkerAsync();

            this.Cursor = Cursors.Wait;
            button.IsEnabled = false;
        }

        private void worker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

            if(e.Error != null)
                MessageBox.Show(e.Error.Message);

            button.IsEnabled = true;
        }

        private void worker_DoWork(
            object sender, DoWorkEventArgs e)
        {
            for(int i = 1; i <= 100; i++)
            {
                // Simulate some processing by sleeping
                Thread.Sleep(100);

                // Call report progress to fire the ProgressChanged event
                worker.ReportProgress(i);
            }
        }

        private void worker_ProgressChanged(
            object sender, ProgressChangedEventArgs e)
        {
            // Update the progress bar
            progressBar.Value = e.ProgressPercentage;
        }
    }
}