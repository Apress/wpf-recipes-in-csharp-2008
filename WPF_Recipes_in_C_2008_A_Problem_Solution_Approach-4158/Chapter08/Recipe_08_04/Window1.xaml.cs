using System.Windows;
using System.Windows.Threading;

namespace Recipe_08_04
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ButtonTrue_Click(object sender, RoutedEventArgs e)
        {
            // Call CheckAccess on the UI thread
            CheckAccess();
        }

        private void ButtonFalse_Click(object sender, RoutedEventArgs e)
        {
            // Invoke a call to CheckAccess 
            // on a different thread
            CheckAccessDelegate del =
                new CheckAccessDelegate(CheckAccess);
            del.BeginInvoke(null, null);
        }

        // Declare a delegate to wrap the CheckAccess method
        private delegate void CheckAccessDelegate();

        // Declare a delegate to wrap the SetResultText method
        private delegate void SetResultTextDelegate(string result);

        private void CheckAccess()
        {
            // Check if the calling thread is in the UI thread
            if(txtResult.Dispatcher.CheckAccess())
            {
                SetResultText("True");
            }
            else
            {
                // The calling thread does not have access to the UI thread.
                // Execute the SetResult method on the Dispatcher of the UI thread.
                txtResult.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new SetResultTextDelegate(SetResultText),
                    "False");
            }
        }

        private void SetResultText(string result)
        {
            // Display the result of the CheckAccess method
            txtResult.Text = result;
        }
    }
}