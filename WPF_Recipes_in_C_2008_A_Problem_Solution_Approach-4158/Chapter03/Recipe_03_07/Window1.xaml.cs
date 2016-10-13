using System.Windows;

namespace Recipe_03_07
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

        // Handles the Button Click event
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Password entered: " + passwordBox.Password,
                Title);
        }
    }
}
