using System.Windows;
using System.Windows.Controls;

namespace Recipe_03_04
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

        // Handles the checking of the Text Alignment RadioButtons. 
        private void AlignmentChecked(object sender, RoutedEventArgs e)
        {
            RadioButton button = e.OriginalSource as RadioButton;

            if (e.OriginalSource == leftAlignRadioButton)
            {
                textBox1.TextAlignment = TextAlignment.Left;
            }
            else if (e.OriginalSource == centerAlignRadioButton)
            {
                textBox1.TextAlignment = TextAlignment.Center;
            }
            else if (e.OriginalSource == rightAlignRadioButton)
            {
                textBox1.TextAlignment = TextAlignment.Right;
            }

            textBox1.Focus();
        }

        // Handles the click of the Append button. Adds text to the end
        // of the TextBox content.
        private void AppendButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.AppendText(" *** appended text ***");
        }

        // Handles the click of the Clear button. Clears all content from
        // the TextBox.
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
        }

        // Handles the click of the Cut button. Cuts the currently 
        // selected text and places it in the clipboard.
        private void CutButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.SelectionLength == 0)
            {
                MessageBox.Show("Select text to cut first.", Title);
            }
            else
            {
                MessageBox.Show("Cut: " + textBox1.SelectedText, Title);

                textBox1.Cut();
            }
        }

        // Handles the checking of the Editable / ReadOnly RadioButtons. 
        private void EditableChecked(object sender, RoutedEventArgs e)
        {
            RadioButton button = e.OriginalSource as RadioButton;

            if (e.OriginalSource == editableRadioButton)
            {
                textBox1.IsReadOnly = false;
            }
            else if (e.OriginalSource == readonlyRadioButton)
            {
                textBox1.IsReadOnly = true;
            }

            textBox1.Focus();
        }

        // Handles the click of the Insert button. Inserts text into
        // the TextBox at the current cursor location.
        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = textBox1.Text.Insert(
                textBox1.CaretIndex, " *** inserted text *** ");
        }

        // Handles the click of the Paste button. Pastes the current 
        // content of the clipboard into the TextBox at the current
        // cursor location.
        private void PasteButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Paste();
        }

        // Handles the click of the Prepend button. Adds text to the start
        // of the TextBox content.
        private void PrependButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = 
                textBox1.Text.Insert(0, "*** Prepended text *** ");
        }

        // Handles the click of the Select All button. Selects all the 
        // content in the TextBox.
        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.SelectAll();

            // Set the focus on the TextBox to make the selection visible.
            textBox1.Focus();
        }

        // Handles the click of the Set Text Button. Sets the content
        // of the TextBox to a default value.
        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "Replace default text with initial text value";
        }

        // Handles the click of the Undo Button. Undoes the last undoable 
        // event.
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Undo();
        }
    }
}
