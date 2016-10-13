using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Recipe_04_04
{
    /// <summary>
    /// A resusable Seach UserControl that raises a 
    /// RoutedEvent when a new search is requested.
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }

        public static RoutedEvent SearchChangedEvent =
            EventManager.RegisterRoutedEvent(
                "SearchChanged",
                RoutingStrategy.Bubble,
                typeof(SearchChangedEventHandler),
                typeof(SearchControl));

        /// <summary>
        /// The SearchChanged event that can be handled
        /// by the consuming control.
        /// </summary>
        public event SearchChangedEventHandler SearchChanged
        {
            add
            {
                AddHandler(SearchChangedEvent, value);
            }
            remove
            {
                RemoveHandler(SearchChangedEvent, value);
            }
        }

        private void SearchButton_Click(
            object sender, 
            RoutedEventArgs e)
        {
            // Raise the SeachChanged RoutedEvent when 
            // the Search button is clicked
            OnSearchChanged();
        }

        private void txtSearch_KeyDown(
            object sender, 
            KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                // Raise the SeachChanged RoutedEvent when 
                // the Enter key is pressed in the Search TextBox
                OnSearchChanged();
            }
        }

        private void OnSearchChanged()
        {
            SearchChangedEventArgs args = 
                new SearchChangedEventArgs(txtSearch.Text);
            args.RoutedEvent = SearchChangedEvent;
            RaiseEvent(args);
        }
    }

    public delegate void SearchChangedEventHandler(
        object sender, 
        SearchChangedEventArgs e);

    public class SearchChangedEventArgs 
        : RoutedEventArgs
    {
        private readonly string searchText;

        public SearchChangedEventArgs(
            string searchText)
        {
            this.searchText = searchText;
        }

        public string SearchText
        {
            get
            {
                return searchText;
            }
        }
    }
}