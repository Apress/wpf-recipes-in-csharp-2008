using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Recipe_10_08
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

        private void Button_ClickMe_Click(object sender, 
            RoutedEventArgs e)
        {
            //Get the position of the mouse, relative to the 
            //button that was clicked.
            Point? position = Mouse.GetPosition(sender as Button);
            //Build a message string to display to the user.
            string msg = string.Format("Wow, you just clicked a " +
                "2D button in 3D!{0}{0}You clicked the button at" +
                " x = {1}, y = {2}", Environment.NewLine, 
                (int)position.Value.X, (int)position.Value.Y);

            MessageBox.Show(msg, "Recipe_10_08");
        }
    }
}
