using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Converter
{
    public sealed partial class ChoicePage : Page
    {
        public ChoicePage()
        {
            this.InitializeComponent();
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), DataContext);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter != "")
            {
                DataContext = e.Parameter;
            }
        }
    }
}
