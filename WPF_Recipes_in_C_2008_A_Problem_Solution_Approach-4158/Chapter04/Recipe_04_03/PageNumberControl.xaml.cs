using System.Windows;
using System.Windows.Controls;

namespace Recipe_04_03
{
    /// <summary>
    /// Show the page number text in the format:
    ///     <!-- Page <Current> of <Total>
    /// </summary>
    public partial class PageNumberControl : UserControl
    {
        public PageNumberControl()
        {
            InitializeComponent();
        }

        public int Current
        {
            get
            {
                return (int) GetValue(CurrentProperty);
            }
            set
            {
                if(value <= Total
                   && value >= 0)
                {
                    SetValue(CurrentProperty, value);
                }
            }
        }

        public static readonly DependencyProperty CurrentProperty =
            DependencyProperty.Register("Current",
                                        typeof(int),
                                        typeof(PageNumberControl),
                                        new PropertyMetadata(0));

        public int Total
        {
            get
            {
                return (int) GetValue(TotalProperty);
            }
            set
            {
                if(value >= Current
                   && value >= 0)
                {
                    SetValue(TotalProperty, value);
                }
            }
        }

        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total",
                                        typeof(int),
                                        typeof(PageNumberControl),
                                        new PropertyMetadata(0));
    }
}