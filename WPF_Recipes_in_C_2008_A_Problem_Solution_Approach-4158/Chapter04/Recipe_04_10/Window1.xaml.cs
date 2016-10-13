using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using Recipe_04_10;

namespace Recipe_04_10
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            ctlFileInput.Click += 
                new RoutedEventHandler(ctlFileInput_Click);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the AutomationPeer for this control
            FileInputControlAutomationPeer peer =
                new FileInputControlAutomationPeer(ctlFileInput);

            IInvokeProvider invokeProvider =
                peer.GetPattern(PatternInterface.Invoke) 
                as IInvokeProvider;

            // Call the Invoke method
            invokeProvider.Invoke();
        }

        private void ctlFileInput_Click(
            object sender, 
            RoutedEventArgs e)
        {
            MessageBox.Show("Invoked via the Automation Peer");
        }
    }
}