using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Converter.ViewModel;
using System.Linq;
using System.Globalization;

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

        private void TextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            var textBox = (TextBox)sender;
            if(textBox.Name == "Box1")
                (DataContext as MainViewModel).Mode = 0;
            else
                (DataContext as MainViewModel).Mode = 1;
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c) && c != '.' && c != DecimalPoint);
        }

        public static char DecimalPoint
        {
            get { return System.Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator); }
        }
    }
}
