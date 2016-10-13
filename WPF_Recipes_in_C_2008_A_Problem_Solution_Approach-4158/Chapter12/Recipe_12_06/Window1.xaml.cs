using System.Windows;
using System.Windows.Input;

namespace Recipe_12_06
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

        // Handles the MouseWheel event on the Slider.
        private void Slider_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Increment or decrement the slider position depending on 
            // whether the wheel was moved up or down.
            sldSlider.Value += (e.Delta > 0) ? 5 : -5;
        }

        // Handles the MouseWheel event on the Rectangle.
        private void Rectangle_MouseWheel(object sender, 
            MouseWheelEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // If the left button is pressed increment or
                // decrement the width.

                double newWidth = 
                    shpRectangle.Width += (e.Delta > 0) ? 5 : -5;

                if (newWidth < 10) newWidth = 10;
                if (newWidth > 200) newWidth = 200;

                shpRectangle.Width = newWidth;
            }
            else
            {
                // If the left button is not pressed increment or 
                // decrement the height.

                double newHeight = 
                    shpRectangle.Height += (e.Delta > 0) ? 5 : -5;

                if (newHeight < 10) newHeight = 10;
                if (newHeight > 200) newHeight = 200;

                shpRectangle.Height = newHeight;
            }
        }
    }
}
