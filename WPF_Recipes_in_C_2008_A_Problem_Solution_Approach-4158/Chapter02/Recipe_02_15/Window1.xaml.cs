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

namespace Recipe_02_15
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

        // Handles Clear Button Click.
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtTextBox.Clear();
        }

        // Handles the Select All Button Click.
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            txtTextBox.SelectAll();
        }

        // Handles all the Button Click events that format the TextBox.
        private void TextStyle_Click(object sender, RoutedEventArgs e)
        {
            if (sender == miNormal)
            {
                txtTextBox.FontWeight = FontWeights.Normal;
                txtTextBox.FontStyle = FontStyles.Normal;
            }
            else if (sender == miBold)
            {
                txtTextBox.FontWeight = FontWeights.Bold;
            }
            else if (sender == miItalic)
            {
                txtTextBox.FontStyle = FontStyles.Italic;
            }
        }
    }
}

