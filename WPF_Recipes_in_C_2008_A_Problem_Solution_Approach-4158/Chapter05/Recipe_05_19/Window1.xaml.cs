using System;
using System.Collections;
using System.Windows;
using System.Windows.Data;
using Recipe_05_19;

namespace Recipe_05_19
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SortButton_Click(
            object sender, RoutedEventArgs args)
        {
            // Get the ObservableCollection from the window Resources
            SortableCountries sortableCountries = 
                (SortableCountries)
                (this.Resources["sortableCountries"]);

            // Get the Default View form the ObservableCollection
            ListCollectionView lcv = 
                (ListCollectionView)
                CollectionViewSource.GetDefaultView(sortableCountries);

            // Set the Custom Sort class
            lcv.CustomSort = new SortCountries();
        }
    }

    public class SortCountries 
        : IComparer
    {
        public int Compare(object x, object y)
        {
            // Custom sorting logic goes here.
            // (Ommitted for brevity).
            //
            string stringX = x.ToString();
            string stringY = y.ToString();

            int ret = 0;

            string[] p = new string[2];
            p[0] = stringX.ToUpper().Trim();
            p[1] = stringY.ToUpper().Trim();

            int[] prefix = new int[2];
            int[] suffix = new int[2];
            string[] mid = new string[2];

            // Parse two parameters
            for(int n = 0; n < 2; n++)
            {
                // Extract numeric prefix
                int midStart = 0;
                for(int i = 0; i < p[n].Length; i++)
                {
                    char ch = p[n][i];
                    if((ch < '0') || (ch > '9'))
                    {
                        midStart = i;
                        break;
                    }

                    prefix[n] = prefix[n] * 10 + (ch - '0');
                }

                // Place numbers below text
                if(prefix[n] == 0)
                    prefix[n] = 999999999;

                // Extract numeric suffix
                int mult = 0;
                int midEnd = p[n].Length - 1;
                for(int i = p[n].Length - 1; i > -1; i--)
                {
                    char ch = p[n][i];
                    if((ch < '0') || (ch > '9'))
                    {
                        midEnd = i;
                        break;
                    }

                    suffix[n] = suffix[n] + ((ch - '0') * (int) Math.Pow(10, mult++));
                }

                // Extract middle string (case-independent)
                mid[n] = p[n].Substring(midStart, midEnd - midStart + 1);
            }

            // Compare the three possible sections of the parameters
            if(prefix[0] < prefix[1])
                ret = -1;
            else if(prefix[0] > prefix[1])
                ret = 1;
            else
            {
                ret = mid[0].CompareTo(mid[1]);
                if(ret == 0)
                {
                    if(suffix[0] < suffix[1])
                        ret = -1;
                    else if(suffix[0] > suffix[1])
                        ret = 1;
                }
            }

            return ret;
        }
    }
}