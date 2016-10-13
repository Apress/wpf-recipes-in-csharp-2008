using System.Windows;
using System.Windows.Controls;

namespace Recipe_12_01
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

        // Handles the click events for all system sound buttons.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                // Simple switch on the name of the button.
                switch (btn.Content.ToString())
                {
                    case "Asterisk":
                        System.Media.SystemSounds.Asterisk.Play();
                        break;
                    case "Beep":
                        System.Media.SystemSounds.Beep.Play();
                        break;
                    case "Exclamation":
                        System.Media.SystemSounds.Exclamation.Play();
                        break;
                    case "Hand":
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case "Question":
                        System.Media.SystemSounds.Question.Play();
                        break;
                    default:
                        string msg = "Sound not implemented: " + btn.Content;
                        MessageBox.Show(msg);
                        break;
                }
            }
        }
    }
}
