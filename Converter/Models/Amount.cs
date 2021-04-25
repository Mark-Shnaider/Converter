using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Converter.Models
{
    class Amount: INotifyPropertyChanged
    {
        public Valute valute {get;set;}
        private double capacity { get; set; }
        public double Capacity
        {
            get { return capacity; }
            set
            {
                capacity = value;
                OnPropertyChanged("Capacity");
            }
        }

        public void Convert(Amount amount2)
        {
            double coef = amount2.valute.Value / amount2.valute.Nominal / valute.Value;
            Capacity = coef * amount2.capacity;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
