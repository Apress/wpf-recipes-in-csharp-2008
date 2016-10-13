using System.Windows;
using Recipe_05_23.Properties;

namespace Recipe_05_23
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Override the OnClosing method and save the current settings
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(
            System.ComponentModel.CancelEventArgs e) 
        { 
            // Save the settings
            Settings.Default.Save(); 

            base.OnClosing(e); 
        }
    }
}