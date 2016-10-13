﻿using System.Windows;
using System.Windows.Input;

namespace Recipe_12_09
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CheckKeyboardState();
        }

        // Handles the Click event on the Button.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckKeyboardState();
        }

        // Checks the state of the keyboard and updates the checkboxes.
        private void CheckKeyboardState()
        {
            // Control keys.
            chkLControl.IsChecked = Keyboard.IsKeyDown(Key.LeftCtrl);
            chkRControl.IsChecked = Keyboard.IsKeyDown(Key.RightCtrl);
            
            // Shift keys.
            chkLShift.IsChecked = Keyboard.IsKeyDown(Key.LeftShift);
            chkRShift.IsChecked = Keyboard.IsKeyDown(Key.RightShift);
            
            // Alt keys.
            chkLAlt.IsChecked = Keyboard.IsKeyDown(Key.LeftAlt);
            chkRAlt.IsChecked = Keyboard.IsKeyDown(Key.RightAlt);
            
            // Num Lock and Caps Lock.
            chkCaps.IsChecked = Keyboard.IsKeyToggled(Key.CapsLock);
            chkNum.IsChecked = Keyboard.IsKeyToggled(Key.NumLock);
        }
    }
}
