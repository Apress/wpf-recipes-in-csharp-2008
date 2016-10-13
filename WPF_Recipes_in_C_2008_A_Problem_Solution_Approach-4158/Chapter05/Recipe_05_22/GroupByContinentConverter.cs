using System;
using System.Globalization;
using System.Windows.Data;
using Recipe_05_22;

namespace Recipe_05_22
{
    public class GroupByContinentConverter 
        : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            Country country = (Country)value;

            // Decide which group the country belongs in
            switch (country.Continent)
            {
                case Continent.NorthAmerica:
                case Continent.SouthAmerica:
                    return "Americas";

                default:
                    return "Rest of the World";
            }
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}