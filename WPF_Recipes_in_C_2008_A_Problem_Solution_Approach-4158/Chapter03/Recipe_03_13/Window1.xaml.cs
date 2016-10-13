using System;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_13
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

        private void SharedButtonClickHandler(object sender, RoutedEventArgs e)
        {
            Button source = e.OriginalSource as Button;           

            if (source != null)
            {
                string message = String.Format("{0} was pressed.", source.Content);
                MessageBox.Show(message, Title);
            }
        }
    }
}
