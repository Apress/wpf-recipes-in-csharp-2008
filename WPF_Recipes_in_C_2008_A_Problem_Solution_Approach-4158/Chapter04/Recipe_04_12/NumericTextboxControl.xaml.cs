using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Recipe_04_12
{
    public partial class NumericTextboxControl : TextBox
    {
        // Flag is True if the Text property is changed
        private bool isTextChanged = false;

        // Flag is True if the Number property is changed
        private bool isNumberChanged = false;

        public NumericTextboxControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Public property to store the numeric 
        /// value of the control's Text property
        /// </summary>
        public double Number
        {
            get
            {
                return (double) GetValue(NumberProperty);
            }
            set
            {
                SetValue(NumberProperty, value);
            }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number",
                                        typeof(double),
                                        typeof(NumericTextboxControl),
                                        new PropertyMetadata(
                                            new PropertyChangedCallback(OnNumberChanged)));

        private static void OnNumberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            NumericTextboxControl control = (NumericTextboxControl) sender;

            if(!control.isTextChanged)
            {
                // Number property has been changed from the outside, 
                // via a binding or control, so set the Text property
                control.isNumberChanged = true;
                control.Text = control.Number.ToString();
                control.isNumberChanged = false;
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if(!isNumberChanged)
            {
                // Text property has been changed from 
                // text input, so set the Number property
                // nb. It will default to 0 if the text
                // is empty or "-"
                isTextChanged = true;
                double number;
                double.TryParse(this.Text, out number);
                this.Number = number;
                isTextChanged = false;
            }

            base.OnTextChanged(e);
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            // Get the preview of the new text
            string newTextPreview =
                this.Text.Insert(
                    this.SelectionStart,
                    e.Text);

            // Try to parse it to a double
            double number;
            if(!double.TryParse(newTextPreview, out number)
               && newTextPreview != "-")
            {
                // Mark the event as being handled if 
                // the new text can't be parsed to a double
                e.Handled = true;
            }

            base.OnPreviewTextInput(e);
        }
    }
}