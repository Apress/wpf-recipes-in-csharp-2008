using System.Windows;
using System.Windows.Controls;

namespace Recipe_01_08
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            UserControl1 uiElement = (UserControl1)sender;

            MessageBox.Show("Rotation = " + Window1.GetRotation(uiElement), 
                            "Recipe_01_08");
        }
    }
}
