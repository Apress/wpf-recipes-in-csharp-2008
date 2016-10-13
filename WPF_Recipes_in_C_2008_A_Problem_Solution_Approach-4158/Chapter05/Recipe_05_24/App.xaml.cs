using System;
using System.Reflection;
using System.Windows;

namespace Recipe_05_24
{
    public partial class App : Application
    {
        /// <summary>
        /// Override the OnStartup method to add the 
        /// resource strings to the Application's ResourceDictionary
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(
            StartupEventArgs e)
        {
            // Use reflection to get the PropertyInfo's for the Properties.Resources class
            Type resourcesType = typeof(Recipe_05_24.Properties.Resources);
            PropertyInfo[] properties = 
                resourcesType.GetProperties(
                    BindingFlags.Static | BindingFlags.NonPublic);

            // Add properties to XAML Application.Resources
            foreach(PropertyInfo property in properties)
            {
                // If the property is a string, add it to the 
                // application's resources dictionay
                if(property.PropertyType == typeof(string))
                    Resources.Add(
                        property.Name, 
                        property.GetValue(null, null));
            }

            base.OnStartup(e);
        }
    }
}