using System.Windows;
using System.Windows.Data;
using Recipe_05_20;

namespace Recipe_05_20
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // Filter the collection of countries. 
        private void CollectionViewSource_EuropeFilter(
            object sender, FilterEventArgs e)
        {
            // Get the data item
            Country country = e.Item as Country;

            // Accept it into the collection view, if its
            // Continent property equals Europe.
            e.Accepted = (country.Continent == Continent.Europe);
        }
    }
}