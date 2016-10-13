using System.Windows;
using Recipe_05_17;

namespace Recipe_05_17
{
    public partial class Window1 : Window
    {
        // Create an instance of the PersonCollection class
        PersonCollection people =
            new PersonCollection();

        public Window1()
        {
            InitializeComponent();

            // Set the DataContext to the PersonCollection
            this.DataContext = people;
        }

        private void AddButton_Click(
            object sender, RoutedEventArgs e)
        {
            people.Add(new Person()
                           {
                               FirstName = "Nelly",
                               LastName = "Bonks",
                               Age = 26,
                               Occupation = "Professional"
                           });
        }
    }
}