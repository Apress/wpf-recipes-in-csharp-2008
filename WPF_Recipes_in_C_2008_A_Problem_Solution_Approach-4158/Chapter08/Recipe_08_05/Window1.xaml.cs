using System.Windows;

namespace Recipe_08_05
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ButtonTrue_Click(object sender, RoutedEventArgs e)
        {
            // Call VerifyAccess on the UI thread
            VerifyAccess();
        }

        private void ButtonFalse_Click(object sender, RoutedEventArgs e)
        {
            // Invoke a call to VerifyAccess 
            // on a different thread
            VerifyAccessDelegate del =
                new VerifyAccessDelegate(VerifyAccess);
            del.BeginInvoke(null, null);
        }

        // Declare a delegate to wrap the VerifyAccess method
        private delegate void VerifyAccessDelegate();

        private void VerifyAccess()
        {
            this.Dispatcher.VerifyAccess();
        }
    }
}