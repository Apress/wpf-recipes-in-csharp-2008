using System.Windows;
using System.Windows.Input;

namespace Recipe_12_05
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

        // Handles the MouseDown event on the Canvas.
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;

            MessageBox.Show("Mouse Down on " + fe.Name, "Canvas");
        }

        // Handles the Click event on the UniformGrid.
        private void UniformGrid_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;

            MessageBox.Show("Mouse Click on " + fe.Name, "Uniform Grid");
        }

        // Handles the MouseDown event on the UniformGrid.
        private void UniformGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;

            MessageBox.Show("Mouse Down on " + fe.Name, "Uniform Grid");
        }
    }
}
