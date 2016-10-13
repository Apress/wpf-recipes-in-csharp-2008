using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;

namespace Recipe_08_02
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Option 1. 
            // If LoadNumbers is called here, the window
            // doesn't show until the method has completed.
            //
            // LoadNumbers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Option 2. 
            // If LoadNumbers is called here, the window
            // loads immediately, but it doesn't display 
            // properly until the method has completed.
            //
            // LoadNumbers();

            // Option 3. 
            // If LoadNumbers is invoked here on the
            // window's Dispather with a DispatcherPriority of 
            // Background, the window will load and be displayed 
            // properly immediately, and then the list of numbers
            // will be generated and displayed once the 
            // method has completed.
            //
            this.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new LoadNumbersDelegate(LoadNumbers));
        }

        // Declare a delegate to wrap the LoadNumbers method
        private delegate void LoadNumbersDelegate();

        // Load one million numbers into a list and 
        // set it as the ItemsSource for the ListBox
        private void LoadNumbers()
        {
            List<string> numberDescriptions = new List<string>();
            for(int i = 1; i <= 1000000; i++)
            {
                numberDescriptions.Add("Number " + i.ToString());
            }

            // Set the ItemsSource
            listBox.ItemsSource = numberDescriptions;
        }
    }
}