using System.Windows;

namespace Recipe_01_13
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string value = 
                ApplicationPropertiesHelper.GetProperty<string>("PropertyKey");

            if (string.IsNullOrEmpty(value))
            {
                value = "Nothing to display!";
            }

            tbxUserText.Text = value;
        }
    }
}
