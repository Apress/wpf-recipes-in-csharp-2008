using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace Recipe_08_03
{
    public partial class Window1 : Window
    {
        // ObservableCollection of strings
        private ObservableCollection<string> numberDescriptions;

        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize an ObservableCollection of strings
            numberDescriptions =
                new ObservableCollection<string>();

            // Set it as the ItemsSource for the ListBox
            listBox.ItemsSource = numberDescriptions;

            // Execute a delegate to load 
            // the first number on the UI thread, with 
            // a priority of Background.
            //
            this.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new LoadNumberDelegate(LoadNumber), 1);
        }

        // Declare a delegate to wrap the LoadNumber method
        private delegate void LoadNumberDelegate(int number);

        private void LoadNumber(int number)
        {
            // Add the number to the observable collection
            // bound to the ListBox
            numberDescriptions.Add("Number " + number.ToString());

            if(number < 10000)
            {
                // Load the next number, by executing this method
                // recursively on the dispatcher queue, with
                // a priority of Background.
                //
                this.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                    new LoadNumberDelegate(LoadNumber), ++number);
            }
        }
    }
}