using System.Collections.ObjectModel;

namespace Recipe_05_19
{
    public class SortableCountries 
        : ObservableCollection<string>
    {
        public SortableCountries()
        {
            this.Add("8 Great Britan");
            this.Add("14 USA");
            this.Add("3 Canada");
            this.Add("6 France");
            this.Add("7 Germany");
            this.Add("10 Italy");
            this.Add("12 Spain");
            this.Add("2 Brazil");
            this.Add("1 Argentina");
            this.Add("4 China");
            this.Add("9 India");
            this.Add("11 Japan");
            this.Add("12 South Africa");
            this.Add("13 Tunisia");
            this.Add("5 Egypt");
        }
    }
}