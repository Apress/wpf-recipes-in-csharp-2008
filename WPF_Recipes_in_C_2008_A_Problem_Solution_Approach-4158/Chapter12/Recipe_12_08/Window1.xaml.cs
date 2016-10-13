using System;
using System.Windows;
using System.Windows.Input;

namespace Recipe_12_08
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // Handles all Key* events for the TextBox and logs them.
        private void TextBox_KeyEvent(object sender, KeyEventArgs e)
        {
            String msg = String.Format("{0} - {1}\n",
                e.RoutedEvent.Name, e.Key);

            txtLog.Text += msg;
            txtLog.ScrollToEnd();
        }

        // Handles all Text* events for the TextBox and logs them.
        private void TextBox_TextEvent(object sender, 
            TextCompositionEventArgs e)
        {
            String msg = String.Format("{0} - {1}\n",
                e.RoutedEvent.Name, e.Text);

            txtLog.Text += msg;
            txtLog.ScrollToEnd();
        }
    }
}
