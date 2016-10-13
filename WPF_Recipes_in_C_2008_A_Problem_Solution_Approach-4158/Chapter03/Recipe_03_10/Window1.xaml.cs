using System.Windows;

namespace Recipe_03_10
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

        // Handles the SliderLeft Click event.
        private void SliderLeft_Click(object sender, RoutedEventArgs e)
        {
            // Reduce the value of the slider by one for each click.
            slider.Value -= 1;
        }

        // Handles the SliderRight Click event.
        private void SliderRight_Click(object sender, RoutedEventArgs e)
        {
            // Increase the value of the slider by one for each click.
            slider.Value += 1;
        }
    }
}
