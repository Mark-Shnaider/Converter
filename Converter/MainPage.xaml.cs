﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Converter.Models;
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
