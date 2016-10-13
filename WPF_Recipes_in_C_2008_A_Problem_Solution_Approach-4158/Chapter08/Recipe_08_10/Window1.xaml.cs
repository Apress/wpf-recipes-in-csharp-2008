using System;
using System.Windows;
using System.Windows.Threading;

namespace Recipe_08_10
{
    public partial class Window1 : Window
    {
        private DispatcherTimer timer;
         
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(timer == null || !timer.IsEnabled)
            {
                timer = new DispatcherTimer();

                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += new EventHandler(timer_Tick);

                timer.Start();
                button.Content = "Stop Timer";
            }
            else
            {
                timer.Stop();
                button.Content = "Start Timer";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            txtStatus.Text = DateTime.Now.Second.ToString();
        }
    }
}