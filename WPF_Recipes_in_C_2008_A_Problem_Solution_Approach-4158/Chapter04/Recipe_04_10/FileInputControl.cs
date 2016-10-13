using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Win32;

namespace Recipe_04_10
{
    [TemplatePart(Name = "PART_Browse", Type = typeof(Button))]
    [ContentProperty("FileName")]
    public class FileInputControl : Control
    {
        static FileInputControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(FileInputControl),
                new FrameworkPropertyMetadata(
                    typeof(FileInputControl)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Button browseButton = base.GetTemplateChild("PART_Browse") as Button;

            if(browseButton != null)
                browseButton.Click += new RoutedEventHandler(browseButton_Click);
        }

        void browseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == true)
            {
                this.FileName = dlg.FileName;
            }
        }

        public string FileName
        {
            get
            {
                return (string) GetValue(FileNameProperty);
            }
            set
            {
                SetValue(FileNameProperty, value);
            }
        }

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileInputControl));

        /// <summary>
        /// Identifies SimpleButton.Click routed event.
        /// </summary>
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
            "Click",
            RoutingStrategy.Bubble,
            typeof(EventHandler),
            typeof(FileInputControl));

        /// <summary>
        /// Ocuurs when a Simple button is clicked.
        /// </summary>
        public event RoutedEventHandler Click
        {
            add
            {
                AddHandler(ClickEvent, value);
            }
            remove
            {
                RemoveHandler(ClickEvent, value);
            }
        }

        /// <summary>
        /// Overriding of this method provides an UI Automation support
        /// </summary>
        /// <returns></returns>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new FileInputControlAutomationPeer(this);
        }
    }

    /// <summary>
    /// Class that provides UI Automation support
    /// </summary>
    public class FileInputControlAutomationPeer 
        : FrameworkElementAutomationPeer, 
          IInvokeProvider
    {
        public FileInputControlAutomationPeer(FileInputControl control)
            : base(control)
        {
        }

        protected override string GetClassNameCore()
        {
            return "FileInputControl";
        }

        protected override string GetLocalizedControlTypeCore()
        {
            return "FileInputControl";
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Button;
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            if(patternInterface == PatternInterface.Invoke)
            {
                return this;
            }

            return base.GetPattern(patternInterface);
        }

        private FileInputControl MyOwner
        {
            get
            {
                return (FileInputControl) base.Owner;
            }
        }

        #region IInvokeProvider Members

        public void Invoke()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FileInputControl.ClickEvent);
            MyOwner.RaiseEvent(newEventArgs);
        }
        #endregion
    }
}