using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Models
{
    class Valute
    {
        public int Id { get; set; }
        public string NumCode { get; set; }
        public string CharCode {get;set;}
        public int Nominal { get; set; }
        public double Value { get; set; }
        public double Previous { get; set; }

        
    }
}
