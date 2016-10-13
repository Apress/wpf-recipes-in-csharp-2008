using System.Globalization;
using System.Windows.Controls;

namespace Recipe_05_15
{
    /// <summary>
    /// ValidationRule class to validate that a value is a
    /// number from 0 to 100.
    /// </summary>
    public class PercentageRule : ValidationRule
    {
        // Override the Validate method to add custom validation logic
        //
        public override ValidationResult Validate(
            object value,
            CultureInfo cultureInfo)
        {
            string stringValue = value as string;

            // Check if there is a value
            if(!string.IsNullOrEmpty(stringValue))
            {
                // Check if the value can be converted to a double
                double doubleValue;
                if(double.TryParse(stringValue, out doubleValue))
                {
                    // Check if the double is between 0 and 100
                    if(doubleValue >= 0 && doubleValue <= 100)
                    {
                        // Return a ValidationResult with the IsValid 
                        // property set to True
                        return new ValidationResult(true, null);
                    }
                }
            }

            // Return a ValidationResult with the IsValid 
            // property set to False. Also specify an error message,
            // which will be displayed in the ToolTip.
            return
                new ValidationResult(
                    false, "Must be a number between 0 and 100");
        }

    }
}