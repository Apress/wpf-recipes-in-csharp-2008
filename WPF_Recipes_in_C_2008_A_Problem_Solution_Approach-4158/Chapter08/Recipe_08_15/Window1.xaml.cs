using System.Windows;
using System.Windows.Threading;

namespace Recipe_08_15
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnWithout_Click(
            object sender, RoutedEventArgs e)
        {
            LoadNumbers(false);
        }

        private void btnWith_Click(
            object sender, RoutedEventArgs e)
        {
            LoadNumbers(true);
        }

        private void LoadNumbers(bool callDoEvents)
        {
            listBox.Items.Clear();

            btnWithout.IsEnabled = false;
            btnWith.IsEnabled = false;

            // Load ten thousand numbers into a listbox
            for(int i = 1; i <= 10000; i++)
            {
                listBox.Items.Add("Number " + i.ToString());

                // Optionally call DoEvents
                if(callDoEvents)
                    DoEvents();
            }

            btnWithout.IsEnabled = true;
            btnWith.IsEnabled = true;
        }

        /// <summary>
        /// Process all messages in the current dispatcher queue
        /// </summary>
        public static void DoEvents()
        {
            // Add an empty delegate to the 
            // current thread's Dispatcher, and 
            // invoke it synchronously but using a 
            // a Background priority.
            // It won't return until all higher priority
            // events in the queue are processed.
            Dispatcher.CurrentDispatcher.Invoke(
                DispatcherPriority.Background,
                new EmptyDelegate(
                    delegate{}));
        }

        private delegate void EmptyDelegate();
    }
}