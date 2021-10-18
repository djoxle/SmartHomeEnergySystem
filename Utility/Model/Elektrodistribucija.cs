using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Model
{
    public class Elektrodistribucija : INotifyPropertyChanged
    {
        private int id = 1;
        private bool razmena;   
        private double cena = 7.392;

        

        public int ID
        {
            get { return id; }
            private set
            {
                if(id != value)
                {
                    id = value;
                }
            }
        }

        public bool Razmena
        {
            get { return razmena; }
            set
            {
               if (razmena != value)
                {
                    razmena = value;
                    RaisePropertyChanged("Razmena");
                }
            }
        }

        public double Cena
        {
            get { return cena; }
            private set
            {
                if(cena != value)
                {
                    cena = value;
                }
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
