using System.Collections.Generic;
using System.Windows;

namespace Recipe_04_11
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Set up the slices 
            pieChart1.Slices = new List <double>();
            pieChart1.Slices.Add(30);
            pieChart1.Slices.Add(60);
            pieChart1.Slices.Add(160);

            pieChart2.Slices = new List <double>();
            pieChart2.Slices.Add(30);
            pieChart2.Slices.Add(90);

            pieChart3.Slices = new List <double>();
            pieChart3.Slices.Add(90);
            pieChart3.Slices.Add(180);
        }
    }
}