using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Input;

namespace Recipe_11_07
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

        bool ignoreValueChanged = false;

        private void Storyboard_Changed(object sender, System.EventArgs e)
        {
            ClockGroup clockGroup = sender as ClockGroup;

            AnimationClock animationClock = clockGroup.Children[0] as AnimationClock;

            if (animationClock.CurrentProgress.HasValue)
            {
                ignoreValueChanged = true;
                Seeker.Value = animationClock.CurrentProgress.Value;
                ignoreValueChanged = false;
            }
        }

        private void Seeker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ignoreValueChanged && Mouse.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            Storyboard.Seek(Rectangle,
                            TimeSpan.FromTicks((long)(Storyboard.Children[0].Duration.TimeSpan.Ticks * Seeker.Value)),
                            TimeSeekOrigin.BeginTime);
        }
    }
}
