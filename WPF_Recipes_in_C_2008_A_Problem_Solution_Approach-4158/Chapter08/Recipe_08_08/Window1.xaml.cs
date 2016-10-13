using System;
using System.ComponentModel;
using System.Windows;
using Recipe_08_08;

namespace Recipe_08_08
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

            // Enable support for cancellation
            worker.WorkerSupportsCancellation = true;

            // Attach the event handlers
            worker.DoWork +=
                new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if(!worker.IsBusy)
            {
                try
                {
                    if(!long.TryParse(txtFrom.Text, out from))
                        throw new ApplicationException("From is not a valid number");

                    if(!long.TryParse(txtTo.Text, out to))
                        throw new ApplicationException("To is not a valid number");

                    // Start the Background Worker
                    worker.RunWorkerAsync();

                    btnStartStop.Content = "Cancel";
                    txtBiggestPrime.Text = string.Empty;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
            if(e.Cancelled)
            {
                // The user canceled the operation
                MessageBox.Show("Operation was canceled");
            }

            btnStartStop.Content = "Start";
            txtBiggestPrime.Text = biggestPrime.ToString();
        }

        private void worker_DoWork(
            object sender, DoWorkEventArgs e)
        {
            // Loop through the numbers, finding the biggest prime
            for(long current = from; current <= to; current++)
            {
                // Check if the BackgroundWorker
                // has been cancelled
                if(worker.CancellationPending)
                {
                    // Set the Cancel property
                    e.Cancel = true;
                    return;
                }

                if(PrimeNumberHelper.IsPrime(current))
                {
                    biggestPrime = current;
                }
            }
        }
    }
}