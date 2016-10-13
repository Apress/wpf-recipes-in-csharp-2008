using System.Windows;

namespace Recipe_04_12
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.numTextBox.Number++;
        }
    }
}