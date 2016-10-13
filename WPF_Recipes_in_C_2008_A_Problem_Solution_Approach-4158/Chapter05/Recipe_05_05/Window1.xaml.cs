using System.Windows;
using Recipe_05_05;

namespace Recipe_05_05
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Set the DataContext to a person object
            this.DataContext = new Person()
                                   {
                                       FirstName = "Nelly",
                                       LastName = "Blinks",
                                       Age = 26
                                   };
        }
    }
}