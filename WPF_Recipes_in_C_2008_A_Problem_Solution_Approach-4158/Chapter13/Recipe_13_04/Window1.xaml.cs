using System;
using System.Windows;
using System.Windows.Media;

namespace Recipe_13_04
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

        // Handles the click of the Winforms button. Changes the fill
        // of the ellipse and changes the button text.
        private void btnWinFormButton_Click(object sender, EventArgs e)
        {
            // Check the current fill of the ellipse.
            if (Ellipse1.Fill == (Brush)Grid1.Resources["RedBrush"])
            {
                // Ellipse is red, change to blue.
                Ellipse1.Fill = (Brush)Grid1.Resources["BlueBrush"];

                // Change the Text on the Winforms button.
                btnWinFormButton.Text = "Make Red";
            }
            else
            {
                // Ellipse is blue, change to red.
                Ellipse1.Fill = (Brush)Grid1.Resources["RedBrush"];

                // Change the Text on the Winforms button.
                btnWinFormButton.Text = "Make Blue";
            }
        }
    }
}
