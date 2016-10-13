using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace Recipe_02_13
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

        private void btnClosePopup_Click(object sender, RoutedEventArgs e)
        {
            popRecipe2_13.IsOpen = false;
        }

        private void btnShowPopup_Click(object sender, RoutedEventArgs e)
        {
            // Determine the correct animation based on the button clicked.
            if (sender == btnFadePopup)
            {
                popRecipe2_13.PopupAnimation = PopupAnimation.Fade;
            }
            else if (sender == btnScrollPopup)
            {
                popRecipe2_13.PopupAnimation = PopupAnimation.Scroll;
            }
            else if (sender == btnSlidePopup)
            {
                popRecipe2_13.PopupAnimation = PopupAnimation.Slide;
            }
            else
            {
                popRecipe2_13.PopupAnimation = PopupAnimation.None;
            }

            // Close the popup if it is open.
            popRecipe2_13.IsOpen = false;

            // Display the popup.
            popRecipe2_13.IsOpen = true;
        }
    }
}
