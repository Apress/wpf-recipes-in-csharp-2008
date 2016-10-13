using System.Windows;
using System.Windows.Input;

namespace Recipe_10_07
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void polygon1_MouseDown(object sender,
            MouseButtonEventArgs e)
        {
            MessageBox.Show("polygon1_MouseDown", "Recipe_10_07");
        }

        private void polygon2_MouseDown(object sender,
            MouseButtonEventArgs e)
        {
            MessageBox.Show("polygon2_MouseDown", "Recipe_10_07");
        }

        private void polygon3_MouseDown(object sender,
            MouseButtonEventArgs e)
        {
            MessageBox.Show("polygon3_MouseDown", "Recipe_10_07");
        }
    }
}
