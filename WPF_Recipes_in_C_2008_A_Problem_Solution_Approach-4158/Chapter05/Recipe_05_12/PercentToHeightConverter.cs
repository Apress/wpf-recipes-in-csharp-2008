using System;
using System.Windows.Data;
using System.Globalization;

namespace Recipe_05_12
{
    [ValueConversion(typeof (double), typeof (double))]
    public class PercentToHeightConverter : IValueConverter
    {
        // Converts a Percent value to a new height value. 
        // The data binding engine calls this method when 
        // it propagates a value from the binding source to the binding target.
        public Object Convert(
            Object value, 
            Type targetType, 
            Object parameter, 
            CultureInfo culture)
        {
            double percent = 
                System.Convert.ToDouble(value);

            // if the value is negative, invert it
            if(percent < 0)
                percent *= -1;

            return percent * 2;
        }

        // Converts a value. The data binding engine calls this 
        // method when it propagates a value from the binding 
        // target to the binding source.
        // As the binding is one-way, this is not implemented.
        public object ConvertBack(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}