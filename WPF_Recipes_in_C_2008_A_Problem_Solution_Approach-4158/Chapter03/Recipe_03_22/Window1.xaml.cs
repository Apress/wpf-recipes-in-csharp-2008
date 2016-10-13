using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_22
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

        // Handles ListBoxItem Selected events for the ListBoxItems in the 
        // inner ListBox.
        private void InnerListBoxItem_Selected(object sender, 
            RoutedEventArgs e)
        {
            ListBoxItem item = e.OriginalSource as ListBoxItem;

            if (item != null)
            {
                MessageBox.Show(item.Content + " was selected.", Title);
            }
        }

        // Handles ListBox SelectionChanged events for the outer ListBox.
        private void OuterListBox_SelectionChanged(object sender, 
            SelectionChangedEventArgs e)
        {
            object item = outerListBox.SelectedItem;

            if (item == null)
            {
                txtSelectedItem.Text = "No item currently selected.";
            }
            else
            {
                txtSelectedItem.Text = item.ToString();
            }
        }
    }
}
