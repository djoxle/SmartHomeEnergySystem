using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_panel_s_.Model
{
    public class SolarniPanel : INotifyPropertyChanged
    {
        private string ime_solarnog_panela;
        private double maksimalna_snaga_solarnog_panela;       //po satu
        private double generisana_snaga;       //U zavisnosti od jacine solarnog panela
        private int id;                     //Za razlikovanje Solarnih Panela medjusobno
        private string tip_solarnog_panela;

        private object objekat = new object();

        public string ImeSolarnogPanela
        {
            get { return ime_solarnog_panela; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ime solarnog panela ne sme biti null.");
                }

                if (ime_solarnog_panela != value)
                {
                    ime_solarnog_panela = value;
                }

            }
        }

        public string TipSolarnogPanelaProperty
        {
            get { return tip_solarnog_panela; }
            set
            {
                if (tip_solarnog_panela != value)
                {
                    tip_solarnog_panela = value;
                }
            }
        }


        public double MaksimalnaSnagaSolarnogPanela
        {
            get { return maksimalna_snaga_solarnog_panela; }

            set
            {
                if (maksimalna_snaga_solarnog_panela != value)
                {
                    maksimalna_snaga_solarnog_panela = value;
                }
            }
        }

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

        /// <summary>
        /// Generisana snaga je povezana sa jacinom Sunca i sluzice da
        /// korisnik bude obavesten o trenutnom radu i promeni generisanja snage.
        /// Zato ovaj property ima RaisePropertyChanged()
        /// </summary>
        public double GenerisanaSnaga
        {
                get
                {
                    lock (objekat)
                    {
                        return generisana_snaga;
                    }
                }          
            
                set
                {
                    lock (objekat)
                    {

                        if (generisana_snaga != value)
                        {
                            generisana_snaga = value;
                            RaisePropertyChanged("GenerisanaSnaga");
                        }
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
