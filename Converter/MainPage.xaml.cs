using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Converter.ViewModel;
using System.Linq;
using System.Globalization;
using System;

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

        private void Box1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var temp = (DataContext as MainViewModel).Amount1;
            //if((DataContext as MainViewModel).Mode == 0)
            //    temp.Capacity = Convert.ToDouble(Box1.Text);
            //(DataContext as MainViewModel).Amount2.Convert(temp);
        }

        private void Box2_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var temp = (DataContext as MainViewModel).Amount2;
            //if ((DataContext as MainViewModel).Mode == 1)
            //    temp.Capacity = Convert.ToDouble(Box2.Text);
            //(DataContext as MainViewModel).Amount1.Convert(temp);
        }
    }
}
