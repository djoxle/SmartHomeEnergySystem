using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES_projekat_5.Model
{
    public class ProizvodnjaSolarnihPanela
    {
        public int ID { get; set; }

        public double Snaga { get; set; }     //Proizvedena Snaga

        public DateTime Datum { get; set; }
    }
}
