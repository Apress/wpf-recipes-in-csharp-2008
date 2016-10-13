using System.Windows;

namespace Recipe_01_13
{
    /// <remark>
    /// This helper is intended to provide the base for a helper
    /// which simplifies use of the Application.Properties property.
    /// The obvious next step in extending the class is to add
    /// argument validation.
    /// </remark>
    public static class ApplicationPropertiesHelper
    {
        /// collection. If the object with the specified key cannot be found,
        /// <summary>
        /// Trys to retrieve a property from the Application's Properties
        /// collection. If the object with the specified key cannot be found,
        /// the default value for the supplied type is returned.
        /// </summary>
        /// <typeparam name="T">The type of object to retrieve.</typeparam>
        /// <param name="key">The key with which the object was stored.</param>
        /// <returns>If the specified key exists, then the associated
        /// value is returned, otherwise the default value for the
        /// specified type.</returns>
        public static T GetProperty<T>(object key)
        {
            if (Application.Current.Properties.Contains(key) 
                && Application.Current.Properties[key] is T)
            {
                return (T)Application.Current.Properties[key];
            }

            return default(T);
        }

        /// <summary>
        /// Retrieves the property associated with the given key.
        /// </summary>
        /// <param name="key">The key with which the object was stored.</param>
        /// <returns>If the specified key exists, the associated
        /// value is returned, otherwise the return value is null.</returns>
        public static object GetProperty(object key)
        {
            if (Application.Current.Properties.Contains(key))
            {
                return Application.Current.Properties[key];
            }

            return null;
        }

        /// <summary>
        /// Adds a value to the Application's properties collection,
        /// indexed by the supplied key.
        /// </summary>
        /// <param name="key">The key against which the value should be stored.</param>
        /// <param name="value">The value to be stored.</param>
        public static void SetProperty(object key, object value)
        {
            Application.Current.Properties[key] = value;
        }
    }
}
