using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Models
{
    class Amount
    {
        public Valute valute {get;set;}

        public double Capacity { get; set; }

        public void Convert(Amount amount2)
        {
            double coef = valute.Value / amount2.valute.Value;
            Capacity = coef * amount2.Capacity;
        }
    }
}
