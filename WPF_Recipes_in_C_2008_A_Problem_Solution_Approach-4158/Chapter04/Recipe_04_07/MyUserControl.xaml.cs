using System.Windows.Controls;

namespace Recipe_04_07
{
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();

            // Call the GetIsInDesignMode method
            if(System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                btnMode.Content = "In Design Mode";
            }
            else
            {
                btnMode.Content = "Runtime";
            }
        }
    }
}