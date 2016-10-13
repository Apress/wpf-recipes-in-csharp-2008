using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Recipe_07_02
{
    public enum TokenType
    {
        Numerical,
        Operator,
        Other
    }

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the content from the rich text box.
            TextRange textRange = 
                new TextRange(rtbTextContent.Document.ContentStart, 
                              rtbTextContent.Document.ContentEnd);

            // We don't want to know about any more changes whilst we're
            // making changes.
            rtbTextContent.TextChanged -= RichTextBox_TextChanged;

            // First clear any formatting applied to the text.
            textRange.ClearAllProperties();

            ApplyFormatting();

            // Start listening for changes again.
            rtbTextContent.TextChanged += RichTextBox_TextChanged;
        }

        private void ApplyFormatting()
        {
            // We want to start from the beginning of the document.
            TextPointer tp = rtbTextContent.Document.ContentStart;

            //Find the next block of text.
            tp = FindNextString(tp);

            while (tp != null)
            {
                TextPointer textRangeEnd = tp.GetPositionAtOffset(1, 
                    LogicalDirection.Forward);

                TextRange tokenTextRange = new TextRange(tp, 
                    tp.GetPositionAtOffset(1, LogicalDirection.Forward));

                TokenType tokenType = ClassifyToken(tokenTextRange.Text);

                switch (tokenType)
                {
                    case TokenType.Numerical:
                        tokenTextRange.ApplyPropertyValue(TextElement.ForegroundProperty, 
                            Brushes.Blue);
                        break;
                    case TokenType.Operator:
                        tokenTextRange.ApplyPropertyValue(TextElement.FontWeightProperty, 
                            FontWeights.Bold);
                        break;
                    case TokenType.Other:
                        tokenTextRange.ApplyPropertyValue(TextElement.FontSizeProperty, 20d);
                        break;
                }

                tp = FindNextString(textRangeEnd);
            }
        }

        private TokenType ClassifyToken(string text)
        {
            int temp;

            if (int.TryParse(text, out temp))
            {
                return TokenType.Numerical;
            }

            switch(text)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                    return TokenType.Operator;
                default:
                    return TokenType.Other;
            }
        }

        private TextPointer FindNextString(TextPointer tp)
        {
            //Skip over anything that isn't text
            while (tp.GetPointerContext(LogicalDirection.Forward) != TextPointerContext.Text)
            {
                tp = tp.GetPositionAtOffset(1, LogicalDirection.Forward);

                if (tp == null)
                {
                    return tp;
                }
            }

            //Skip over any whitespace we meet
            char[] buffer = new char[1];
            tp.GetTextInRun(LogicalDirection.Forward, buffer, 0, 1);

            while (IsWhiteSpace(buffer))
            {
                tp = tp.GetPositionAtOffset(1, LogicalDirection.Forward);

                if (tp == null)
                {
                    break;
                }

                tp.GetTextInRun(LogicalDirection.Forward, buffer, 0, 1);
            }

            return tp;
        }

        private bool IsWhiteSpace(char[] buffer)
        {
            return (buffer[0] == '\n' 
                    || buffer[0] == '\t' 
                    || buffer[0] == '\r' 
                    || buffer[0] == ' ');
        }
    }
}
