using System;
using System.Windows;

namespace Recipe_11_15
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

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Storyboard complete.", "Recipe_11_15");
        }

        private void ParallelTimeline_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("ParallelTimeline complete.", "Recipe_11_15");
        }

        private void Animation1_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Animation 1 complete.", "Recipe_11_15");
        }

        private void Animation2_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Animation 2 complete.", "Recipe_11_15");
        }

        private void Animation3_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Animation 3 complete.", "Recipe_11_15");
        }
    }
}
