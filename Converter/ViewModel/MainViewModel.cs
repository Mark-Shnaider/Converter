using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Converter.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Diagnostics;

namespace Converter.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Valute> Valutes { get; set; }
        public Amount Amount1 { get; set; }
        public Amount Amount2 { get; set; }
        public int Mode { get; set; } = 0;
        public ICommand SelectCommand { get; set; }
        public ICommand ConvertCommand { get; set; }
        public MainViewModel()
        {

            SelectCommand = new RelayCommand(() =>
            {
                if (Amount1.valute != null && Amount2.valute != null)
                {
                    if (Mode == 0)
                    {
                        Amount1.Convert(Amount2);
                        Mode = 1;
                    }
                    else
                    {
                        Amount2.Convert(Amount1);
                        Mode = 0;
                    }
                }
            });

            ConvertCommand = new RelayCommand(() =>
            {
                if (Mode == 0)
                    Amount2.Convert(Amount1);
                else
                    Amount1.Convert(Amount2);
            });

            try
            {
                Valutes = Parser.TakeData();
            }
            catch(Exception e)
            { 
                Debug.WriteLine("Problem with parsing:");
                Debug.WriteLine($"{e.Message}");
            }

            Valutes.Add(new Valute
            {
                ID = "Template",
                NumCode = "643",
                CharCode = "RUB",
                Nominal = 1,
                Name = "Российский рубль",
                Value = 1,
                Previous = 1
            });
            //Сделано для того, чтобы сразу были данные на странице
            Amount1 =  new Amount { valute = Valutes[0], Capacity = 1} ;
            Amount2 =  new Amount { valute = Valutes[0], Capacity = 1} ;
            Amount1.Convert(Amount2);
        }
        

        public Valute MySelectedItem
        {
            get
            {
                if (Mode == 0)
                    return Amount1.valute;
                return Amount2.valute;
            }
            set
            {
                if (Mode == 0)
                    Amount1.valute = value;
                else
                    Amount2.valute = value;
                OnPropertyChanged("MySelectedItem");
            }
        }
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
