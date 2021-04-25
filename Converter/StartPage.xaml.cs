using System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Converter.ViewModel;

namespace Converter
{
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainViewModel();
            Thread.Sleep(1000);
            Frame.Navigate(typeof(MainPage), DataContext);
        }
    }
}

