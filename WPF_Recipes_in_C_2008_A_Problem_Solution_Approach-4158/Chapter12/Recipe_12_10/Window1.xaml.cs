using System.Windows;
using System.Windows.Input;

namespace Recipe_12_10
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked", "Button");
        }

        private void StackPanel_PreviewMouseDown(object sender, 
            MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
