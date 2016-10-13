using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_01_06
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

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            DependencyPropertyDescriptor descriptor = 
                DependencyPropertyDescriptor.FromProperty(TextBox.TextProperty, typeof(TextBox));

            descriptor.AddValueChanged(tbxEditMe, tbxEditMe_TextChanged);
            
        }

        private void tbxEditMe_TextChanged(object sender, EventArgs e)
        {
            //Do something
        }
    }
}
