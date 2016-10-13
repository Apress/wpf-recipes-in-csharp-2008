using System;
using System.Windows;
using System.Windows.Threading;

namespace Recipe_01_04
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        /// <summary>
        /// Contructor for the demo's main Window. Here a simple dispatcher
        /// timer is created simply for the purpose of demonstrating how
        /// a read-only dependency property can be set.
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            DispatcherTimer timer = 
                new DispatcherTimer(TimeSpan.FromSeconds(1), 
                                    DispatcherPriority.Normal, 
                                    delegate 
                                    {
                                        //Increment the value stored in Counter
                                        int newValue = Counter == int.MaxValue ? 0 : Counter + 1;
                                        //Uses the SetValue which accepts a 
                                        //System.Windows.DependencyPropertyKey
                                        SetValue(counterKey, newValue); 
                                    }, 
                                    Dispatcher);
        }

        /// <summary>
        /// The standard CLR property wrapper. Note the wrapper is
        /// read only too, so as to maintain consistency.
        /// </summary>
        public int Counter
        {
            get { return (int)GetValue(counterKey.DependencyProperty); }
        }

        /// <summary>
        /// The <see cref="System.Windows.DependencyPropertyKey"/> field which
        /// provides access to the <see cref="System.Windows.DependencyProperty"/>
        /// which backs the above CLR property.
        /// </summary>
        private static readonly DependencyPropertyKey counterKey = 
            DependencyProperty.RegisterReadOnly("Counter", 
                                                typeof(int), 
                                                typeof(Window1), 
                                                new PropertyMetadata(0));
    }
}
