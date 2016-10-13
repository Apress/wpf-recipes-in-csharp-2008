using System.Windows;
using Recipe_04_04;

namespace Recipe_04_04
{
    /// <summary>
    /// This window creates an instance of SearchControl
    /// and handles the SearchChanged event, showing the
    /// new search text in a message box 
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SearchControl_SearchChanged(
            object sender, 
            SearchChangedEventArgs e)
        {
            MessageBox.Show("New Search: " + e.SearchText);
        }
    }
}