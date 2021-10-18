using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES_projekat_5.Model
{
    public class SnagaElektrodistribucija
    {
        public int ID { get; set; }

        public double Snaga { get; set; }     //proizvodnja - potrosnja

        public double Cena { get; set; }

        public DateTime Datum { get; set; }
    }
}
