using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Converter.ViewModel;

namespace Converter
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Choice_Click(object sender, RoutedEventArgs e)
        {
            var clicker = (Button)sender;
            if (clicker.Name == "Button1")
                (DataContext as MainViewModel).Mode = 0;
            else
                (DataContext as MainViewModel).Mode = 1;

            Frame.Navigate(typeof(ChoicePage), DataContext);
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
