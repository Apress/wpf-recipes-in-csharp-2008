using System.Windows;
using System;

namespace Recipe_01_05
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Override the meta-data for the DataContextProperty 
            // of the Window, altering the default value and 
            // registering a property changed callback.
            DataContextProperty.OverrideMetadata(
                typeof(Window1), 
                new FrameworkPropertyMetadata(
                        100d, 
                        new PropertyChangedCallback(DataContext_PropertyChanged)));

        }

        private static void DataContext_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string msg =
                string.Format("DataContext changed.{0}{0}Old Value: {1}{0}New Value: {2}",
                              Environment.NewLine,
                              e.OldValue.ToString(), 
                              e.NewValue.ToString());

            MessageBox.Show(msg, "Recipe_01_05");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = tbxUserText.Text;            
        }
    }
}
