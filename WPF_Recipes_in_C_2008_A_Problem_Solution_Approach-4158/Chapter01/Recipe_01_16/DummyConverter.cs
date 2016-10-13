using System;
using System.Globalization;
using System.Windows.Data;

namespace Recipe_01_16
{
    public class DummyConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, 
                              Type targetType, 
                              object parameter, 
                              CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, 
                                  Type targetType, 
                                  object parameter, 
                                  CultureInfo culture)
        {
            return value;
        }

        #endregion
    }
}
