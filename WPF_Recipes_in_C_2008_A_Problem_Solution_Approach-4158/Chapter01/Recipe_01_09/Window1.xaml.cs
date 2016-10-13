using System.Windows;

namespace Recipe_01_09
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            Parent parent = new Parent();
            parent.PropertyThatInherits = "Still Inherits.";
            parent.PropertyThatDoesNotInherit = "Still not inheriting.";

            Child child = new Child();
            parent.Children.Add(child);

            DataContext = new object[]{parent, child};
        }
    }
}
