using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Recipe_01_15
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

        /// <summary>
        /// When the main window is loaded, we want to spawm some
        /// windows to play with.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            Brush[] backgrounds = new Brush[5]{ Brushes.Red, 
                                                Brushes.Blue, 
                                                Brushes.Green, 
                                                Brushes.Yellow, 
                                                Brushes.HotPink};
            //Create 5 windows.
            for (int i = 1; i <= 5; i++)
            {
                Window window = new Window();

                SetupWindow(window, "Window " + i, backgrounds[i - 1]);
                //Show the window.
                window.Show();
            }
            
            RebuildWindowList();
        }

        /// <summary>
        /// When the main window closes, we want to close all the child windows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window1_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SetupWindow(Window window, string title, Brush background)
        {
            // We want to know when a window is closing so we can prevent
            // it from being closed if required.
            window.Closing += new CancelEventHandler(Window_Closing);

            // We want to know when a window has been closed so we can
            // rebuild our list of open windows.
            window.Closed += new EventHandler(Window_Closed);

            // Give the window a title so we can track it.
            window.Title = title;
            window.Width = 100d;
            window.Height = 100d;

            // Create a text block displaying the window's title inside 
            // a view box for the window's content.
            Viewbox viewBox = new Viewbox();
            TextBlock textBlock = new TextBlock();

            //Set the window's background to make it easier to identify.
            window.Background = background;
            viewBox.Child = textBlock;
            textBlock.Text = window.Title;
            window.Content = viewBox;
        }

        /// <summary>
        /// This method iterates all the windows for this application
        /// and adds them to the list box lbxWindows.
        /// </summary>
        private void RebuildWindowList()
        {
            List<Window> windows = new List<Window>();

            foreach (Window window in Application.Current.Windows)
            {
                if (window == this)
                    continue;

                windows.Add(window);
            }

            lbxWindows.ItemsSource = windows;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            RebuildWindowList();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Window w = sender as Window;

            if (w == null)
                return;

            e.Cancel = !cbxCanClose.IsChecked == true;
        }

        private void CheckBox_Checked_Changed(object sender, RoutedEventArgs e)
        {
            //Get the selected window.
            Window window = lbxWindows.SelectedItem as Window;

            if (window == null) 
                return;

            if (cbxIsVisible.IsChecked == true)
                window.Show();
            else
                window.Hide();
        }

        private void btnBringToFront_Click(object sender, RoutedEventArgs e)
        {
            Window window = lbxWindows.SelectedItem as Window;

            if (window != null)
                window.Activate();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window window = lbxWindows.SelectedItem as Window;

            if (window != null)
                window.Close();
        }
    }
}
