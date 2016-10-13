using System;
using System.Windows;
using System.Windows.Threading;

namespace Recipe_08_16
{
    public partial class ChildWindow : Window
    {
        private bool continueCalculating = false;

        private PrimeNumberHelper primeNumberHelper
            = new PrimeNumberHelper();

        public ChildWindow()
            : base()
        {
            InitializeComponent();
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if(continueCalculating)
                Stop();
            else
                Start();
        }

        public void Start()
        {
            continueCalculating = true;
            btnStartStop.Content = "Stop";

            // Execute the CheckPrimeNumber method on
            // the current Dispatcher queue
            this.Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                new Action<int>(CheckPrimeNumber), 3);
        }

        public void Stop()
        {
            continueCalculating = false;
            btnStartStop.Content = "Start";

            // Add an empty delegate to the 
            // current thread's Dispatcher, and 
            // invoke it synchronously but using a 
            // a Background priority.
            // This ensures the Stop method won't return 
            // until the CheckPrimeNumber method has completed.
            Dispatcher.CurrentDispatcher.Invoke(
                DispatcherPriority.Background,
                new EmptyDelegate(
                    delegate{}));
        }

        public void CheckPrimeNumber(int current)
        {
            if(primeNumberHelper.IsPrime(current))
            {
                txtBiggestPrime.Text = current.ToString();
            }

            if(continueCalculating)
            {
                // Execute the CheckPrimeNumber method 
                // again, using a lower DispatherPriority
                this.Dispatcher.BeginInvoke(
                    DispatcherPriority.SystemIdle,
                    new Action<int>(CheckPrimeNumber), current + 2);

                if(chkSleep.IsChecked.Value)
                    System.Threading.Thread.Sleep(200);
            }
        }

        private delegate void EmptyDelegate();
    }
}