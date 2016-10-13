using System;
using System.Windows;

namespace Recipe_06_09
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                lbl.Style = (Style)FindResource("lblNighttimeStyle");
                img.Style = (Style)FindResource("imgNighttimeStyle");
            }
            else
            {
                lbl.Style = (Style)FindResource("lblDaytimeStyle");
                img.Style = (Style)FindResource("imgDaytimeStyle");
            }
        }
    }
}
