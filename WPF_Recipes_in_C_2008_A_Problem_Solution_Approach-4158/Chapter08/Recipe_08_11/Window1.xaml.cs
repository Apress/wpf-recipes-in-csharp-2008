using System.Windows;
using System.Threading;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace Recipe_08_11
{
    public partial class Window1 : Window
    {
        private Storyboard pulseStoryboard;
        private BackgroundWorker worker;

        public Window1()
        {
            InitializeComponent();

            pulseStoryboard
                = (Storyboard) this.Resources["PulseStoryboard"];

            // Set the animation to repeat indefinately
            pulseStoryboard.RepeatBehavior = RepeatBehavior.Forever;

            // Create a Background Worker
            worker = new BackgroundWorker();

            worker.DoWork +=
                new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        private void button_Click(
            object sender, RoutedEventArgs e)
        {
            // Begin the animation
            pulseStoryboard.Begin(this, true);

            // Start the Background Worker
            worker.RunWorkerAsync();

            button.IsEnabled = false;
        }

        private void worker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            button.IsEnabled = true;

            // Stop the animation
            pulseStoryboard.Stop(this);
        }

        private void worker_DoWork(
            object sender, DoWorkEventArgs e)
        {
            for(int i = 1; i <= 50; i++)
            {
                Thread.Sleep(50);
            }
        }
    }
}