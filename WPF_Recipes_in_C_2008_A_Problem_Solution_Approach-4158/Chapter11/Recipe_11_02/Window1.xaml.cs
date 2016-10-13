using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Recipe_11_02
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            Loaded += delegate(object sender, RoutedEventArgs e)
            {
                //Set the data context of the Window to itself.
                //This will make binding to the dependency properties,
                //defined below, a great deal easier.
                DataContext = this;
            };
        }

        // Gets or sets the AutoReverseAnimationProperty
        public bool AutoReverseAnimation
        {
            get { return (bool)GetValue(AutoReverseAnimationProperty); }
            set { SetValue(AutoReverseAnimationProperty, value); }
        }

        public static readonly DependencyProperty AutoReverseAnimationProperty =
            DependencyProperty.Register("AutoReverseAnimation", typeof(bool), typeof(Window1), new UIPropertyMetadata(false, DependencyProperty_Changed));

        // Gets or sets the value of the StoryboardDuration property.
        public Duration StoryboardDuration
        {
            get { return (Duration)GetValue(StoryboardDurationProperty); }
            set { SetValue(StoryboardDurationProperty, value); }
        }

        public static readonly DependencyProperty StoryboardDurationProperty =
            DependencyProperty.Register("StoryboardDuration", typeof(Duration),
                typeof(Window1), new UIPropertyMetadata(new Duration(TimeSpan.FromSeconds(1)), DependencyProperty_Changed));

        // Handles changes to the value of either the StoryboardDuration dependency                 
        // property or the EllipseFilleBrush dependency property and invokes the 
        // ReapplyStoryboard method, updating the animation to reflect the new 
        // values.
        private static void DependencyProperty_Changed(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Window1 window1 = sender as Window1;

            if (window1 != null)
            {
                window1.ReapplyStoryboard();
            }
        }

        // Reapplies the 'ellipseStoryboard' object to the 'ellipse' object
        // defined in the associated markup of the window.
        private void ReapplyStoryboard()
        {
            if (!this.IsInitialized)
            {
                return;
            }

            //Attempt to get the current time of the active storyboard.
            //If this is null, a TimeSpan of 0 is used to start the storyboard
            //from the beginning.
            TimeSpan? currentTime = ellipseStoryboard.GetCurrentTime(this)
                                    ?? TimeSpan.FromSeconds(0);
            //Restart the storyboard.
            ellipseStoryboard.Begin(this, true);
            //Seek to the same position that the storyboard was before it was
            //restarted.
            ellipseStoryboard.Seek(this, currentTime.Value,
                TimeSeekOrigin.BeginTime);
        }

        private void Slider_ValueChanged(object sender,
                         RoutedPropertyChangedEventArgs<double> e)
        {
            StoryboardDuration = TimeSpan.FromSeconds(e.NewValue);
        }
    }
}
