using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Recipe_11_03
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        #region Method 2

        /// <summary>
        /// Handler for the Button.Click event on the 'Method 2' button.
        /// This method removes the animations effecting the button
        /// using the BeginAnimation() method, passing a null reference
        /// for the value of the System.Windows.Media.Animation.AnimationTimeline.
        /// </summary>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            //Cast the sender to a button.
            Button button2 = sender as Button;
            //Remove any active animations against the Button's width property.
            button2.BeginAnimation(Button.WidthProperty, null);
            //Remove any active animations against the Button's height property.
            button2.BeginAnimation(Button.OpacityProperty, null);
        }

        #endregion

        #region Method 3

        //Store a reference to the AnimationClock objects when they are created.
        //This allows for the clocks to be accessed later when it comes to
        //removing them.
        private AnimationClock opacityClock;
        private AnimationClock widthClock;

        //Method which handles the Button.Loaded event on the 'Method 3' button.
        //Animations are created and applied to 'button3', storing a reference to
        //the clocks which are created.
        private void Button3_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation(1d, 0.5d, TimeSpan.FromSeconds(1), FillBehavior.HoldEnd);
            opacityAnimation.RepeatBehavior = RepeatBehavior.Forever;
            opacityAnimation.AutoReverse = true;
            opacityClock = opacityAnimation.CreateClock();
            button3.ApplyAnimationClock(Button.OpacityProperty, opacityClock);

            DoubleAnimation widthAnimation = new DoubleAnimation(140d, 50d, TimeSpan.FromSeconds(1), FillBehavior.HoldEnd);
            widthAnimation.RepeatBehavior = RepeatBehavior.Forever;
            widthAnimation.AutoReverse = true;
            widthClock = widthAnimation.CreateClock();
            button3.ApplyAnimationClock(Button.WidthProperty, widthClock);
        }

        //Handles the Button.Click event of 'button3'. This uses the third
        //method of removing animations by removing each of the clocks.
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            opacityClock.Controller.Remove();
            widthClock.Controller.Remove();
        }        

        #endregion

        #region Method 4

        //Store a local reference to the storyboard we want to 
        //interact with.
        private Storyboard method4Storyboard;

        private void Button4_Loaded(object sender, RoutedEventArgs e)
        {
            method4Storyboard = TryFindResource("Storyboard1") as Storyboard;

            method4Storyboard.Begin(sender as FrameworkElement, true);
        }

        //Handles the Button.Click event of the 'Method 4' button.
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            //Make sure we got a valid reference.
            if (method4Storyboard != null)
            {
                //Remove the storyboard by calling its Remove method, passing the
                //control that it is currently running against.
                method4Storyboard.Remove(sender as FrameworkElement);
            }
        }

        #endregion
    }
}
