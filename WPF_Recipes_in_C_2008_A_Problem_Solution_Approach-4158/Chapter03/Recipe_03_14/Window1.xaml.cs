using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_14
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

        // Handles all GetSliderValue Button Clicks
        private void GetSliderValue_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;
            string message = "Unknown slider.";

            if (button == btnGetSliderValue1)
            {
                message = "Slider1 value = " + slider1.Value;
            }
            else if (button == btnGetSliderValue2)
            {
                message = "Slider2 value = " + slider2.Value;
            }

            MessageBox.Show(message, Title);
        }

        // Handles all Slider ValueChangedEvents.
        private void slider_ValueChanged(object sender, 
            RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = e.OriginalSource as Slider;

            if (slider != null)
            {
                txtSliderValue.Text = slider.Value.ToString();
            }
        }
    }
}
