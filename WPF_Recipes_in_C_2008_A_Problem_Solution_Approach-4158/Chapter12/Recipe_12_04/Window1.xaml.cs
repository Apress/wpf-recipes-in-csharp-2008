using System;
using System.Windows;
using System.Windows.Input;

namespace Recipe_12_04
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

        // Handles the Click event on the Button.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mouse Click", "Button");
        }

        // Handles the MouseDoubleClick event on the Label.
        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Mouse Double Click", "Label");
        }

        // Handles the MouseDown event on the Rectangle.
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Mouse Down", "Rectangle");
        }

        // Handles the MouseUp event on the TextBlock.
        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Mouse Up", "TextBlock");
        }
    }
}