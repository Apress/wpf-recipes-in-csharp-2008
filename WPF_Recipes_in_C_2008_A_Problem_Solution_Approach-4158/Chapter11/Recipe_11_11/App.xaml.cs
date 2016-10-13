using System.Windows;
using System.Windows.Media.Animation;

namespace Recipe_11_11
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += delegate(object sender, StartupEventArgs e)
            {
                Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline),
                                                   new PropertyMetadata(1));
            };
        }
    }
}
