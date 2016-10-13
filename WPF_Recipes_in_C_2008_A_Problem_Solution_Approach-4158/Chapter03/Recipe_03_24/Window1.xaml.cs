using System;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_24
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

        // Gets the currently selected ComboBoxItem when the user
        // clicks the Button. If the SelectedItem of the ComboBox
        // is null, the code checks to see if the user has entered
        // text into the ComboBox instead.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = comboBox.SelectedItem as ComboBoxItem;

            if (item != null)
            {
                MessageBox.Show("Current item: " + item.Content, Title);
            }
            else if (!String.IsNullOrEmpty(comboBox.Text))
            {
                MessageBox.Show("Text entered: " + comboBox.Text, Title);
            }
        }

        // Handles ComboBox SelectionChanged events.
        private void ComboBox_SelectionChanged(object sender, 
            SelectionChangedEventArgs e)
        {
            // Do not handle events until Window is fully initialized.
            if (!IsInitialized) return;

            ComboBoxItem item = comboBox.SelectedItem as ComboBoxItem;

            if (item != null)
            {
                MessageBox.Show("Selected item: " + item.Content, Title);
            }
        }

        // Handles ComboBoxItem Selected events.
        private void ComboBoxItem_Selected(object sender,
            RoutedEventArgs e)
        {
            // Do not handle events until Window is fully initialized.
            if (!IsInitialized) return;

            ComboBoxItem item = e.OriginalSource as ComboBoxItem;

            if (item != null)
            {
                MessageBox.Show(item.Content + " was selected.", Title);
            }
        }
    }
}
