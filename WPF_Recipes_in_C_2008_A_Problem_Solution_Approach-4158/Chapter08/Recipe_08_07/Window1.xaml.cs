using System;
using System.ComponentModel;
using System.Windows;
using Recipe_08_07;

namespace Recipe_08_07
{
    public partial class Window1 : Window
    {
        private BackgroundWorker worker;

        private long from;
        private long to;
        private long biggestPrime;

        public Window1()
            : base()
        {
            InitializeComponent();

            // Create a Background Worker
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            // Attach the event handlers
            worker.DoWork +=
                new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += worker_ProgressChanged;
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!long.TryParse(txtFrom.Text, out from))
                    throw new ApplicationException("From is not a valid number");

                if(!long.TryParse(txtTo.Text, out to))
                    throw new ApplicationException("To is not a valid number");

                // Start the Background Worker
                worker.RunWorkerAsync();

                btnStartStop.IsEnabled = false;
                txtBiggestPrime.Text = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void worker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            btnStartStop.IsEnabled = true;
            txtBiggestPrime.Text = biggestPrime.ToString();
        }

        private void worker_DoWork(
            object sender, DoWorkEventArgs e)
        {
            // Loop through the numbers, finding the biggest prime
            for(long current = from; current <= to; current++)
            {
                if(PrimeNumberHelper.IsPrime(current))
                {
                    biggestPrime = current;

                    // Call report progress to fire the ProgressChanged event
                    int percentComplete = Convert.ToInt32(((double) current / to) * 100d);
                    worker.ReportProgress(percentComplete);
                  
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        private void worker_ProgressChanged(
            object sender, ProgressChangedEventArgs e)
        {
            // Update the progress bar
            txtPercent.Text = e.ProgressPercentage.ToString() + "%";
        }
    }
}