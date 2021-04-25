using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Converter.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Converter.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public Amount Amount1 { get; set; }
        public Amount Amount2 { get; set; }

        public ObservableCollection<Valute> Valutes {get;set;}

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Valutes = Parser.TakeData();

            Amount1 = new Amount {Capacity = 5, valute = Valutes[10]};
            Amount2 = new Amount {Capacity = 1, valute = Valutes[11]};
            Amount2.Convert(Amount1);
        }
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
