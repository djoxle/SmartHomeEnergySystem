

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battery.Model
{
    public class Baterija : INotifyPropertyChanged
    {
        private int id;
        private string ime;
        private int maksimalna_snaga;              //Definisano od strane proizvodjaca
        private double kapacitet;          //Za tri sata se napuni do maksimalne snage



        public int ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                }

            }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                if (ime != value)
                {
                    ime = value;
                }
            }
        }

        public int MaksimalnaSnaga
        {
            get { return maksimalna_snaga; }
            set
            {
                if (maksimalna_snaga != value)
                {
                    maksimalna_snaga = value;
                }
            }
        }

        public double Kapacitet
        {
            get { return kapacitet; }

            set {
                    if (kapacitet != value)
                    {
                        kapacitet = value;
                        RaisePropertyChanged("UkupanKapacitet");
                    }
                }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        [ExcludeFromCodeCoverage]
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
