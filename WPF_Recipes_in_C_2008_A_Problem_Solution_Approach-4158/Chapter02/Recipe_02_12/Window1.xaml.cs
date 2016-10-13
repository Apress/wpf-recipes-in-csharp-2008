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

namespace Recipe_02_12
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

        private void btnMessageOnly_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A simple MessageBox.");
        }

        private void btnMessageHeader_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A MessageBox with a title.", 
                "WPF Recipes Chapter 2");
        }

        private void btnMessageHeaderButton_Click(object sender, 
            RoutedEventArgs e)
        {
            MessageBox.Show("A MessageBox with a title and buttons.", 
                "WPF Recipes Chapter 2",
                MessageBoxButton.YesNoCancel);
        }

        private void btnMessageHeaderButtonImage_Click(object sender, 
            RoutedEventArgs e)
        {
            MessageBox.Show("A MessageBox with a title, buttons, and an icon.",
                "WPF Recipes Chapter 2",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Warning);
        }
    }
}
