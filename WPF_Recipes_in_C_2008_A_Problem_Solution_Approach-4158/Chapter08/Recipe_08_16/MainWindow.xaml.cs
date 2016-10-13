using System.Windows;
using System.Threading;
using System.Collections.Generic;

using Recipe_08_16;

namespace Recipe_08_16
{
    public partial class MainWindow : Window
    {
        private List<ChildWindow> windows = new List<ChildWindow>();
        private List<Thread> threads = new List<Thread>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewWindow_Click(object sender, RoutedEventArgs e)
        {
            if(chkCreateThread.IsChecked.Value)
            {
                // Create a new Thread
                // which will create a new window
                Thread newWindowThread = new Thread(new ThreadStart(ThreadStartingPoint));
                newWindowThread.SetApartmentState(ApartmentState.STA);
                newWindowThread.IsBackground = true;
                newWindowThread.Start();

                threads.Add(newWindowThread);
            }
            else
            {
                // Create a new window
                ChildWindow window = new ChildWindow();
                window.Show();

                windows.Add(window);
            }
        }

        private void ThreadStartingPoint()
        {
            // Create a new window
            ChildWindow window = new ChildWindow();
            window.Show();

            // Start the new window's Dispatcher
            System.Windows.Threading.Dispatcher.Run();
        }

        private void btnCloseWindows_Click(object sender, RoutedEventArgs e)
        {
            foreach(ChildWindow window in windows)
            {
                window.Stop();
                window.Close();
            }
            windows.Clear();

            foreach(Thread thread in threads)
            {
                thread.Abort();
            }
            threads.Clear();
        }
    }
}