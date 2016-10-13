using System;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace Recipe_06_08
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type type = typeof(FrameworkElement);

            // Get the DefaultStyleKeyProperty dependency 
            // property of FrameworkElement
            FieldInfo fieldInfo = type.GetField(
                                    "DefaultStyleKeyProperty",
                                    BindingFlags.Static
                                  | BindingFlags.NonPublic);

            DependencyProperty defaultStyleKeyProperty =
                            (DependencyProperty)fieldInfo.GetValue
                                (MyProgressBar);

            // Get the value of the property for the 
            // progress bar element
            object defaultStyleKey =
                MyProgressBar.GetValue(defaultStyleKeyProperty);

            // Get the style from the application's resources
            Style style =
                (Style)Application.Current.FindResource
                    (defaultStyleKey);

            // Save the style to a string
            string styleXaml = XamlWriter.Save(style);
        }
    }
}
