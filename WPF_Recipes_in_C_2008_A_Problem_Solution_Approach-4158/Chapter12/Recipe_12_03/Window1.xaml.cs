using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Recipe_12_03
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        bool ignoreValueChanged = false;

        public Window1()
        {
            InitializeComponent();
        }

        // Handles the opening of the media file and sets the Maximum
        // value of the position slider based on the natural duration
        // of the media file.
        private void MediaOpened(object sender, EventArgs e)
        {
            sldPosition.Maximum = 
                meMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        // Updates the position slider when the media time changes.
        private void Storyboard_Changed(object sender, EventArgs e)
        {
            ClockGroup clockGroup = sender as ClockGroup;

            MediaClock mediaClock = clockGroup.Children[0] as MediaClock;

            if (mediaClock.CurrentProgress.HasValue)
            {
                ignoreValueChanged = true;
                sldPosition.Value = meMediaElement.Position.TotalMilliseconds;
                ignoreValueChanged = false;
            }
        }

        // Handles the movement of the slider and updates the position 
        // being played.
        private void sldPosition_ValueChanged(object sender, 
            RoutedPropertyChangedEventArgs<double> e)
        {
            if (ignoreValueChanged)
            {
                return;
            }

            Storyboard.Seek(Panel,
                TimeSpan.FromMilliseconds(sldPosition.Value),
                TimeSeekOrigin.BeginTime);
        }
    }
}
