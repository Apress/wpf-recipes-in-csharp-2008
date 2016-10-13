using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_19
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

        // Handles the Submit Button Click event.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = null;

            // Try the first (left) container to see if one of
            // the radio buttons in Group1 is checked.
            radioButton = GetCheckedRadioButton(
                spLeftContainer.Children, "Group1");

            // If no RadioButton in the first container is checked, try
            // the second (right) container.
            if (radioButton == null)
            {
                radioButton = GetCheckedRadioButton(
                    spRightContainer.Children, "Group1");
            }

            // We must have at least one RadioButton checked to display.
            MessageBox.Show(radioButton.Content + " checked.", Title);
        }

        // A method that loops through a UIElementCollection and identifies
        // a checked RadioButton with a specified group name.
        private RadioButton GetCheckedRadioButton(
            UIElementCollection children, String groupName)
        {
            return children.OfType<RadioButton>().
                FirstOrDefault( rb => rb.IsChecked == true 
                    && rb.GroupName == groupName);
        }

        // Handles the RadioButton Checked event for all buttons in Group2.
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Don't handle events until the Window is fully initialized.
            if (!this.IsInitialized) return;

            RadioButton radioButton = e.OriginalSource as RadioButton;

            if (radioButton != null)
            {
                MessageBox.Show(radioButton.Content + " checked.", Title);
            }
        }
    }
}
