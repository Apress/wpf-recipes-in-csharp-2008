using System;
using System.Windows;
using System.ComponentModel;
using Recipe_08_06;

namespace Recipe_08_06
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

            // Attach the event handlers
            worker.DoWork +=
                new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!long.TryParse(txtFrom.Text, out from))
                    throw new ApplicationException("From is not a valid number");

                if(!long.TryParse(txtTo.Text, out to))
                    throw new ApplicationException("To is not a valid number");

                // Start the Background Worker
                worker.RunWorkerAsync();

                btnStart.IsEnabled = false;
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
            btnStart.IsEnabled = true;
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
                }
            }
        }
    }
}