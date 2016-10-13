using System.Collections.ObjectModel;

namespace Recipe_06_12
{
    public class Country
    {
        private string name;
        private Continent continent;

        public Country(string name, Continent continent)
        {
            this.name = name;
            this.continent = continent;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Continent Continent
        {
            get
            {
                return continent;
            }
            set
            {
                continent = value;
            }
        }

    }

    public enum Continent
    {
        Asia,
        Africa,
        Europe,
        NorthAmerica,
        SouthAmerica,
        Australasia
    }

    public class Countries : Collection<Country>
    {
        public Countries()
        {
            this.Add(new Country("Great Britan", Continent.Europe));
            this.Add(new Country("USA", Continent.NorthAmerica));
            this.Add(new Country("Canada", Continent.NorthAmerica));
            this.Add(new Country("France", Continent.Europe));
            this.Add(new Country("Germany", Continent.Europe));
            this.Add(new Country("Italy", Continent.Europe));
            this.Add(new Country("Spain", Continent.Europe));
            this.Add(new Country("Brazil", Continent.SouthAmerica));
            this.Add(new Country("Argentina", Continent.SouthAmerica));
            this.Add(new Country("China", Continent.Asia));
            this.Add(new Country("India", Continent.Asia));
            this.Add(new Country("Japan", Continent.Asia));
            this.Add(new Country("South Africa", Continent.Africa));
            this.Add(new Country("Tunisia", Continent.Africa));
            this.Add(new Country("Egypt", Continent.Africa));
        }
    }
}
