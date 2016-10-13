using System.Windows;

namespace Recipe_09_02
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Populate the PointsCollection of the PolyLine.
            plLine.Points.Add(new Point(10, 140));
            plLine.Points.Add(new Point(270, 140));
            plLine.Points.Add(new Point(270, 220));
            plLine.Points.Add(new Point(255, 220));
            plLine.Points.Add(new Point(230, 175));
            plLine.Points.Add(new Point(205, 220));
            plLine.Points.Add(new Point(180, 175));
            plLine.Points.Add(new Point(155, 220));
            plLine.Points.Add(new Point(130, 175));
            plLine.Points.Add(new Point(10, 175));
            plLine.Points.Add(new Point(10, 220));
            plLine.Points.Add(new Point(125, 220));
        }
    }
}
