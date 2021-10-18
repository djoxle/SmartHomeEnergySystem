using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumers.Model
{
    public class Potrosac : INotifyPropertyChanged
    {
        private string ime;
        private double potrosnja;          //po satu, treba to imati u vidu pri slanju podataka SHES-u
        private int id;
        private bool upaljen;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        public string Ime
        {
            get { return ime; }
            set { if (ime != value) ime = value; }
        }

        public double Potrosnja
        {
            get { return potrosnja; }
            set {

                if (potrosnja != value)
                {
                    potrosnja = value;
                    RaisePropertyChanged("Potrosnja");
                }
            }
        }

        public bool Upaljen
        {
            get { return upaljen; }

            set
            {
                if (upaljen != value)
                {
                    upaljen = value;
                    RaisePropertyChanged("Upaljen");
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
