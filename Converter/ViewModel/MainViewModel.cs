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
        public Valute Valute1 { get; set; }
        public Valute Valute2 { get; set; }

        public ObservableCollection<Valute> Valutes {get;set;}

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            Valutes = Parser.TakeData();

            Valute1 = new Valute { ID = "123", Name = "Деньга1", CharCode = "RUB" };
            Valute2 = new Valute { ID = "321", Name = "Деньга2", CharCode = "USD" };
        }
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
