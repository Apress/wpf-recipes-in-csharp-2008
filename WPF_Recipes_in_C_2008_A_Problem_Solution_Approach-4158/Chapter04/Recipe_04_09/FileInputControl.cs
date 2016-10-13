using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Recipe_04_09
{
    /// <summary>
    /// The TemplatePart attribute specifies that the control
    /// expects the Control Template to contain a Button called 
    /// PART_Browse
    /// </summary>
    [TemplatePart(Name = "PART_Browse", Type = typeof(Button))]
    public class FileInputControl : Control
    {
        static FileInputControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(FileInputControl), 
                new FrameworkPropertyMetadata(
                    typeof(FileInputControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Use the GetTemplateChild method to locate
            // the button called PART_Browse
            Button browseButton = base.GetTemplateChild("PART_Browse") as Button;
             
            // Do not cause or throw an exception 
            // if it wasn't supplied by the Template
            if(browseButton != null)
                browseButton.Click += new RoutedEventHandler(browseButton_Click);
        }

        void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == true)
            {
                this.FileName = dlg.FileName;
            }
        }

        public string FileName
        {
            get
            {
                return (string) GetValue(FileNameProperty);
            }
            set
            {
                SetValue(FileNameProperty, value);
            }
        }

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileInputControl));
    }
}