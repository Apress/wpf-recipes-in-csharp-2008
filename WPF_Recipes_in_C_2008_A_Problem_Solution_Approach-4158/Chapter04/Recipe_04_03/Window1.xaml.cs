using System.Windows;

namespace Recipe_04_03
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void DecreaseCurrent_Click(object sender, 
                                           RoutedEventArgs e)
        {
            pageNumberControl.Current--;
        }

        private void IncreaseCurrent_Click(object sender, 
                                           RoutedEventArgs e)
        {
            pageNumberControl.Current++;
        }

        private void DecreaseTotal_Click(object sender, 
                                         RoutedEventArgs e)
        {
            pageNumberControl.Total--;
        }

        private void IncreaseTotal_Click(object sender, 
                                         RoutedEventArgs e)
        {
            pageNumberControl.Total++;
        }
    }
}