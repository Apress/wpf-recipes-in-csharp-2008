using System;
using System.Windows;
using System.Windows.Threading;
using Recipe_08_01;

namespace Recipe_08_01
{
    public partial class Window1 : Window
    {
        private bool continueCalculating = false;

        public Window1() : base()
        {
            InitializeComponent();
        }

        private void StartStop_Click(object sender, RoutedEventArgs e)
        {
            if(continueCalculating)
            {
                continueCalculating = false;
                btnStartStop.Content = "Start";
            }
            else
            {
                continueCalculating = true;
                btnStartStop.Content = "Stop";

                // Execute the CheckPrimeNumber method on
                // the current Dispatcher queue
                this.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action<int>(CheckPrimeNumber), 3);
            }
        }

        public void CheckPrimeNumber(int current)
        {
            if(PrimeNumberHelper.IsPrime(current))
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
            }
        }
    }
}