using System;
using System.Windows;
using System.Windows.Controls;

namespace Recipe_06_19
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SkinsComboBox_SelectionChanged(
                         object sender,
                         SelectionChangedEventArgs e)
        {
            ResourceDictionary resourceDictionary;
            Skin skin = (Skin)((ComboBox)sender).SelectedItem;

            switch (skin)
            {
                case Skin.Red:
                    resourceDictionary = Application.LoadComponent(
                        new Uri(@"Skins/RedResources.xaml",
                            UriKind.Relative)) as ResourceDictionary;
                    break;

                case Skin.Green:
                    resourceDictionary = Application.LoadComponent(
                        new Uri(@"Skins/GreenResources.xaml",
                            UriKind.Relative)) as ResourceDictionary;
                    break;

                case Skin.Blue:
                    resourceDictionary = Application.LoadComponent(
                        new Uri(@"Skins/BlueResources.xaml",
                            UriKind.Relative)) as ResourceDictionary;
                    break;

                default:
                    resourceDictionary = Application.LoadComponent(
                        new Uri(@"Skins/DefaultResources.xaml",
                            UriKind.Relative)) as ResourceDictionary;
                    break;
            }

            Application.Current.Resources = resourceDictionary;
        }
    }

    public enum Skin
    {
        Default,
        Red,
        Green,
        Blue
    }
}
