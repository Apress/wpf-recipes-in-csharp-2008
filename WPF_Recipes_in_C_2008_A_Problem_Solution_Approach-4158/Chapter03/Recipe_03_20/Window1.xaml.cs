using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_20
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

        // Handles Button Click event to populate the ListBox with
        // the names of the currently checked CheckBox controls.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Clear the content of the ListBox.
            listbox.Items.Clear();

            // Process each CheckBox control in the main StackPanel.
            foreach (CheckBox checkbox in panel.Children.OfType<CheckBox>()
                .Where( cb => cb.IsChecked == true))
            {
                listbox.Items.Add(checkbox.Name);
            }
        }

        // Handles all the CheckBox Checked events to display a message
        // when a CheckBox changes to a checked state.
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Don't handle these events during initialization.
            if (!IsInitialized) return;

            CheckBox checkbox = e.OriginalSource as CheckBox;

            if (checkbox != null)
            {
                MessageBox.Show(checkbox.Name + " is checked.", Title);
            }
        }

        // Handles all the CheckBox Indeterminate events to display a message
        // when a CheckBox changes to a indeterminate state.
        private void CheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            // Don't handle these events during initialization.
            if (!IsInitialized) return;

            CheckBox checkbox = e.OriginalSource as CheckBox;

            if (checkbox != null)
            {
                MessageBox.Show(checkbox.Name + " is indeterminate.", Title);
            }
        }

        // Handles all the CheckBox Unchecked events to display a message
        // when a CheckBox changes to a unchecked state.
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Don't handle these events during initialization.
            if (!IsInitialized) return;

            CheckBox checkbox = e.OriginalSource as CheckBox;

            if (checkbox != null)
            {
                MessageBox.Show(checkbox.Name + " is unchecked.", Title);
            }
        }
    }
}
