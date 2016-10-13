using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Recipe_04_06
{
    /// <summary>
    /// Show the page number text in the format:
    ///     <!-- Page <Current> of <Total>
    /// </summary>
    public partial class PageNumberControl : UserControl
    {
        private static RoutedCommand increaseTotalCommand;

        public static RoutedCommand IncreaseTotal
        {
            get
            {
                return increaseTotalCommand;
            }
        }

        static PageNumberControl()
        {
            // Create an input gesture so that the command 
            // is executed when the Add (+) key is pressed
            InputGestureCollection myInputs = 
                new InputGestureCollection();
            myInputs.Add(
                new KeyGesture(
                    Key.Add, 
                    ModifierKeys.Control));

            // Create a RoutedCommand
            increaseTotalCommand = 
                new RoutedCommand(
                    "IncreaseTotal", 
                    typeof(PageNumberControl), 
                    myInputs);

            // Create a CommandBinding, specifying the 
            // Execute and CanExecute handlers
            CommandBinding binding = 
                new CommandBinding();

            binding.Command = increaseTotalCommand;
            binding.Executed += 
                new ExecutedRoutedEventHandler(binding_Executed);
            binding.CanExecute += 
                new CanExecuteRoutedEventHandler(binding_CanExecute);

            // Register the CommandBinding
            CommandManager.RegisterClassCommandBinding(
                typeof(PageNumberControl), binding);
        }

        public PageNumberControl()
        {
            InitializeComponent();
        }

        static void binding_CanExecute(
            object sender, 
            CanExecuteRoutedEventArgs e)
        {
            // The command can execute as long as the 
            // Total is less than the maximum integer value
            PageNumberControl control = (PageNumberControl) sender;
            e.CanExecute = control.Total < int.MaxValue;
        }

        private static void binding_Executed(
            object sender, 
            ExecutedRoutedEventArgs e)
        {
            // Increment the value of Total when
            // the command is executed
            PageNumberControl control = (PageNumberControl) sender;
            control.Total++;
        }

        public int Current
        {
            get
            {
                return (int) GetValue(CurrentProperty);
            }
            set
            {
                if(value <= Total
                   && value >= 0)
                {
                    SetValue(CurrentProperty, value);
                }
            }
        }

        public static readonly DependencyProperty CurrentProperty =
            DependencyProperty.Register("Current",
                                        typeof(int),
                                        typeof(PageNumberControl));

        public int Total
        {
            get
            {
                return (int) GetValue(TotalProperty);
            }
            set
            {
                if(value >= Current
                   && value >= 0)
                {
                    SetValue(TotalProperty, value);
                }
            }
        }

        public static readonly DependencyProperty TotalProperty =
            DependencyProperty.Register("Total",
                                        typeof(int),
                                        typeof(PageNumberControl));
    }
}