using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Recipe_03_23
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

        // Handles the Add Item Button Click event.
        private void btnAddListItem_Click(object sender, 
            RoutedEventArgs e)
        {
            // Ensure there is text to add.
            if (textBox.Text.Length == 0)
            {
                MessageBox.Show("Enter text to add to the list.", Title);
            }
            else
            {
                // Wrap the text in a ListBoxItem and configure.
                ListBoxItem item = new ListBoxItem();
                item.Content = textBox.Text;
                item.IsSelected = true;
                item.HorizontalAlignment = HorizontalAlignment.Center;
                item.FontWeight = FontWeights.Bold;
                item.FontFamily = new FontFamily("Tahoma");

                // Add the ListBoxItem to the ListBox
                listBox1.Items.Add(item);

                // Clear the content of the textBox and give it focus.
                textBox.Clear();
                textBox.Focus();
            }
        }

        // Handles the Delete Item Button Click event.
        private void btnDeleteListItem_Click(object sender, 
            RoutedEventArgs e)
        {
            // Ensure there is at least one item selected.
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select list items to delete.", Title);
            }
            else
            {
                // Iterate through the selected items and remove each one.
                // Cannot use foreach because we are changing the underlying
                // data.
                while (listBox1.SelectedItems.Count > 0)
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[0]);
                }
            }
        }

        // Handles the Select All Button Click.
        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            listBox1.SelectAll();
        }
    }
}
