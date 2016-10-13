using System.Windows;
using System.Windows.Forms;

namespace Recipe_13_03
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Form1 modelessForm;
        private FormClosingEventHandler modelessFormCloseHandler;

        public Window1()
        {
            InitializeComponent();
            modelessFormCloseHandler = 
                new FormClosingEventHandler(ModelessFormClosing);
        }

        // Handles the Windows Form Closing event for the modeless form.
        private void ModelessFormClosing(object sender, FormClosingEventArgs e)
        {
            // Remove the event handler reference.
            modelessForm.FormClosing -= modelessFormCloseHandler;
            modelessForm = null;

            // Change the button text.
            btnOpenModeless.Content = "Open Modeless Form";
        }

        // Handles the button click event to open the modal Windows Form.
        private void OpenModal_Click(object sender, RoutedEventArgs e)
        {
            // Create and display the modal form.
            Form1 form = new Form1();
            form.ShowDialog();
        }
        
        // Handles the button click event to open and close the modeless 
        // Windows Form.
        private void OpenModeless_Click(object sender, RoutedEventArgs e)
        {
            if (modelessForm == null)
            {
                modelessForm = new Form1();

                // Add an event handler to get notification when the form
                // is closing.
                modelessForm.FormClosing += modelessFormCloseHandler;

                // Change the button text.
                btnOpenModeless.Content = "Close Modeless Form";

                // Show the Windows Form.
                modelessForm.Show();
            }
            else
            {
                modelessForm.Close();
            }
        }
    }
}
