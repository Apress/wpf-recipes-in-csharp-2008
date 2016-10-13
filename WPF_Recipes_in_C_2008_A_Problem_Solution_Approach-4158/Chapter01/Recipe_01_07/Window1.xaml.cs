using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Recipe_01_07
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //Set the window's DataContext to itself to simplify 
            //the binding paths for the UserValue property.
            DataContext = this;
        }

        //The CLR wrapper for the DependencyProperty
        public int UserVaule
        {
            get { return (int)GetValue(UserValueProperty); }
            set { SetValue(UserValueProperty, value); }
        }

        //The dependency property backing store.
        public static readonly DependencyProperty UserValueProperty = 
            DependencyProperty.Register("UserValue", 
                                        typeof(int), 
                                        typeof(Window1), 
                                        new PropertyMetadata(1, UserValue_PropertyChangedCallback), 
                                                             ValidateIntRange_ValidationCallbackHandler);

        //Validation callback for the above UserValue dependency property.
        private static bool ValidateIntRange_ValidationCallbackHandler(object value)
        {
            //Try to parse the value to an int.
            int intValue;

            if (int.TryParse(value.ToString(), out intValue))
            {
                //The value is an integer so test its value.
                if (intValue >= 1 && intValue <= 100)
                {
                    return true;
                }
            }

            return false;
        }

        //Property changed callback for the above UserValue dependency property.
        private static void UserValue_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window1 window1 = d as Window1;

            if (window1 != null)
            {                
                window1.uv.Foreground = Brushes.SeaGreen;
            }
        }

        //Handler for the PreviewKeyDown event on the TextBox
        private void TextBox_PreviewKeyDown(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                textBox.Foreground = Brushes.Firebrick;
            }
        }
    }
}
