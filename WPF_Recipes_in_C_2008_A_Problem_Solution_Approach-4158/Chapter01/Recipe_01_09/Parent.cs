using System.Windows;
using System.Windows.Controls;

namespace Recipe_01_09
{
    public class Parent : StackPanel
    {
        public string PropertyThatInherits
        {
            get { return (string)GetValue(PropertyThatInheritsProperty); }
            set { SetValue(PropertyThatInheritsProperty, value); }
        }

        public static readonly DependencyProperty PropertyThatInheritsProperty
            = DependencyProperty.RegisterAttached("PropertyThatInherits",
                                                  typeof(string),
                                                  typeof(UIElement),
                                                  new FrameworkPropertyMetadata("Inherits.",
                                                              FrameworkPropertyMetadataOptions.Inherits));

        public string PropertyThatDoesNotInherit
        {
            get { return (string)GetValue(PropertyThatDoesNotInheritProperty); }
            set { SetValue(PropertyThatDoesNotInheritProperty, value); }
        }

        public static readonly DependencyProperty PropertyThatDoesNotInheritProperty
            = DependencyProperty.RegisterAttached("PropertyThatDoesNotInherit",
                                                  typeof(string),
                                                  typeof(UIElement),
                                                  new FrameworkPropertyMetadata("Does not inherit."));
    }
}
