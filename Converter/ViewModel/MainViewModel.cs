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
        public Valute Valute1;
        public Valute Valute2;

        public ObservableCollection<Valute> Valutes {get;set;}

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            var Valutes = Parser.TakeData();
        }
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
