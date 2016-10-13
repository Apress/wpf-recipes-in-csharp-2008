using System.Windows;
using System.Windows.Controls;
using Recipe_05_14;

namespace Recipe_05_14
{
    public class TaskItemDataTemplateSelector
        : DataTemplateSelector
    {
        // Override the SelectTemplate method to 
        // return the desired DataTemplate.
        //
        public override DataTemplate SelectTemplate(
            object item,
            DependencyObject container)
        {
            if (item != null &&
               item is TaskItem)
            {
                TaskItem taskitem = item as TaskItem;

                Window window = Application.Current.MainWindow;

                // To run in design mode test for design mode, and 
                // return null, as it will not find the DataTemplate resources
                // in the code below.
                if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(window))
                    return null;

                // Check the Priority of hte TaskItem to 
                // determine the DataTemplate to display it.
                //
                if (taskitem.Priority == 1)
                {
                    // Use the window's FindResource method to 
                    // locate the DataTemplate
                    return
                        window.FindResource(
                            "highPriorityTaskTemplate") as DataTemplate;
                }
                else
                {
                    return
                        window.FindResource(
                            "defaultTaskTemplate") as DataTemplate;
                }
            }

            return null;
        }
    }
}