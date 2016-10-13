using System;
using System.Windows;
using System.Windows.Threading;

namespace Recipe_01_02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            string msg = 
                string.Format("An unhandled exception has occurred.{0}{0}{1}", 
                              Environment.NewLine,
                              e.Exception);

            MessageBox.Show(msg, "Recipe_01_02");

            //Handling this event will result in the application
            //remaining alive. This is useful if you are able to
            //recover from the exception.
            e.Handled = true;
        }
    }
}
