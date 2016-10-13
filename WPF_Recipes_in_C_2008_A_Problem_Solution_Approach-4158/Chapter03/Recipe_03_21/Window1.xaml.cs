using System;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_21
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

        // Handles the Selected event for all TreeViewItems.
        private void TreeViewItem_Selected(object sender, 
            RoutedEventArgs e)
        {
            String message = String.Empty;

            // As the Selected event is fired by successive
            // parent TreeViewItem controls of the actually
            // selected TreeViewItem, the sender will change,
            // but the e.OriginalSource will continue to 
            // refer to the TreeViewItem that was actually 
            // clicked.
            TreeViewItem item = sender as TreeViewItem;

            if (item == e.OriginalSource)
            {
                // Event raised by clicked item.
                message =
                    String.Format("Item selected: {0} ({1} child items)",
                    item.Header, item.Items.Count);
            }
            else
            {
                // Event raised by a parent of clicked item.
                message =
                    String.Format("Parent of selected: {0} ({1} child items)",
                    item.Header, item.Items.Count);
            }

            MessageBox.Show(message, Title);
        }

        // Handles the Button Click event.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = tvTree.SelectedItem as TreeViewItem;

            if (item != null)
            {
                MessageBox.Show("Item selected: " + item.Header, Title);
            }
            else
            {
                MessageBox.Show("No item selected", Title);
            }
        }
    }
}
