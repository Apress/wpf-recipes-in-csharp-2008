using System.Windows;
using Recipe_05_16;

namespace Recipe_05_16
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Set the DataContext to a person object
            this.DataContext =
                new Person()
                    {
                        FirstName = "Elin",
                        LastName = "Binkles",
                        Age = 26,
                    };
        }
    }
}