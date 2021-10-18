using RES_projekat_5.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RES_projekat_5.View
{
    [ExcludeFromCodeCoverage] //Deo UI-a
    /// <summary>
    /// Interaction logic for ShesViewModel.xaml
    /// </summary>
    public partial class ShesView : UserControl
    {
        private DateTime datum;
        private string solarni_paneli;
        private string baterija;
        private string elektrodistribucija1;
        private string elektrodistribucija2;
        private string potrosaci;

        public ShesView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public DateTime Datum
        {
            get { return datum; }
            set
            {
                datum = value;
            }
        }

        public string SolarniPaneli
        {
            get { return solarni_paneli; }
            set { Solarni_Paneli.Text = value; solarni_paneli = value; }
        }

        public string Baterija
        {
            get { return baterija; }
            set {Baterijaa.Text = value; baterija = value; }
        }

        public string Potrosaci
        {
            get { return potrosaci; }
            set { Potrosacii.Text = value; potrosaci = value; }
        }

        public string Elektrodistribucija1
        {
            get { return elektrodistribucija1; }
            set { Elektrodistribucijaa1.Text = value; elektrodistribucija1 = value; }
        }

        public string Elektrodistribucija2
        {
            get { return elektrodistribucija2; }
            set { Elektrodistribucijaa2.Text = value; elektrodistribucija2 = value; }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (datum == null)
            {
                MessageBox.Show("Izaberite datum", "Upozorenje", MessageBoxButton.OK);
                return;
            }

            double solarni_panelii = 0;
            double baterijaa = 0;
            double elektrodistribucija = 0;
            double potrosacii = 0;
            double cena = 0;

            Izvestaji context = new Izvestaji();

            foreach (var item in context.Elektrodistribucije.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    cena = item.Cena;
                    elektrodistribucija += item.Snaga;
                }
            }

            if (elektrodistribucija > 0)
            {
                Elektrodistribucija2 = "Prodaja";
            }
            else if(elektrodistribucija < 0)
            {
                Elektrodistribucija2 = "Kupovina";
            }
            else
            {
                Elektrodistribucija2 = "Optimum";
            }

            Elektrodistribucija1 = (cena * elektrodistribucija).ToString();

            foreach (var item in context.Potrosaci.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    potrosacii += item.Snaga;
                }
            }

            Potrosaci = (potrosacii * cena * (-1)).ToString();

            foreach (var item in context.Baterije.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    baterijaa += item.Snaga;
                }
            }

            Baterija = (baterijaa * cena).ToString();

            foreach (var item in context.SolarniPaneli.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    solarni_panelii += item.Snaga;
                }
            }

            SolarniPaneli = (solarni_panelii * cena).ToString();

        }
    }
}
