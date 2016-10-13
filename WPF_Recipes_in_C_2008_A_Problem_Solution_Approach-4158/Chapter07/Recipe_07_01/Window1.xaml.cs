using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Recipe_07_01
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            // Check to see we have some valid insertion text.
            if (string.IsNullOrEmpty(tbxInsertionText.Text))
            {
                return;
            }

            // Mark the text control as being changed. This prevents
            // any text content or selection changed events and
            // combines any steps performed before the EndChange into
            // a single undo action.
            rtbTextContent.BeginChange();

            // First clear any selected text.
            if (rtbTextContent.Selection.Text != string.Empty)
            {
                rtbTextContent.Selection.Text = string.Empty;
            }

            // Get the text element adjacent to the caret in its current
            // position.
            TextPointer tp =
                rtbTextContent.CaretPosition.GetPositionAtOffset(0, 
                    LogicalDirection.Forward);

            // Insert the text we have supplied
            rtbTextContent.CaretPosition.InsertTextInRun(tbxInsertionText.Text);

            // Now restore the caret's position so that it is placed
            // after the newly inserted text.
            rtbTextContent.CaretPosition = tp;

            //We have finished making our changes.
            rtbTextContent.EndChange();

            // Now set the focus back to RichTextBox so the user can 
            // continue typing.
            Keyboard.Focus(rtbTextContent);
        }
    }
}
