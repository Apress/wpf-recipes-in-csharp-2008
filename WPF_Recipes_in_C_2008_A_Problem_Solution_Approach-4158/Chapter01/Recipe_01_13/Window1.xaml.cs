using System.Windows;

namespace Recipe_01_13
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationPropertiesHelper.SetProperty("PropertyKey", tbxUserText.Text);

            Window2 window2 = new Window2();

            window2.ShowDialog();
        }
    }
}
