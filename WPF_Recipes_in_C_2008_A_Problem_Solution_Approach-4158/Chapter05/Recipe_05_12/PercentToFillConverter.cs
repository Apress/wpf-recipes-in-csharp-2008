using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;
using System.Collections.Generic;

namespace Recipe_05_12
{
    [ValueConversion(typeof (double), typeof (Brush))]
    public class PercentToFillConverter : IValueConverter
    {
        // Declares a Brush to use for negative data items
        private static readonly Brush negativeColor =
            new LinearGradientBrush(
                new GradientStopCollection(
                    new List<GradientStop>(
                        new GradientStop[] 
                            {
                                new GradientStop(
                                    Color.FromArgb(255, 165, 0, 0), 0), 
                                new GradientStop(
                                    Color.FromArgb(255, 132, 0, 0), 0)
                            }
                        )), 
                new Point(0.5,0), 
                new Point(0.5,1));

        // Declares a Brush to use for positive data items
        private static readonly Brush positiveColor = 
            new LinearGradientBrush(
                new GradientStopCollection(
                    new List<GradientStop>(
                        new GradientStop[] 
                            {
                                new GradientStop(
                                    Color.FromArgb(255, 0, 165, 39), 1), 
                                new GradientStop(
                                    Color.FromArgb(255, 0, 132, 37), 0)
                            }
                        )),
                new Point(0.5, 0),
                new Point(0.5, 1));


        // Converts a Percent value to a Fill value. 
        // Returns a Brush based on whether Percent is positive or negative.
        // The data binding engine calls this method when 
        // it propagates a value from the binding source to the binding target.
        public Object Convert(
            Object value, 
            Type targetType, 
            Object parameter, 
            CultureInfo culture)
        {
            double percent = System.Convert.ToDouble(value);

            if(percent > 0)
            {
                return  positiveColor;
            }
            else
            {
                return negativeColor;
            }
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