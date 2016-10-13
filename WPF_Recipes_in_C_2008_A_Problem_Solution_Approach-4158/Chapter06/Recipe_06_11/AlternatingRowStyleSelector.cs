using System.Windows;
using System.Windows.Controls;

namespace Recipe_06_11
{
    public class AlternatingRowStyleSelector : StyleSelector
    {
        public Style DefaultStyle
        {
            get;
            set;
        }

        public Style AlternateStyle
        {
            get;
            set;
        }

        // Flag to track the alternate rows
        private bool isAlternate = false;

        public override Style SelectStyle(object item, DependencyObject container)
        {
            // Select the style, based on the value of isAlternate
            Style style = isAlternate ? AlternateStyle : DefaultStyle;

            // Invert the flag
            isAlternate = !isAlternate;

            return style;
        }
    }
}
