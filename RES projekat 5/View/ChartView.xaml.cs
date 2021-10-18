using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public int[] Labele { get; set; }
        public Func<double, string> YOsa { get; set; }

        private DateTime datum;

        public ChartView()
        {
            SeriesCollection = new SeriesCollection();

            DataContext = this;
            InitializeComponent();

            YOsa = value => value.ToString("F");
        }

        public DateTime Datum
        {
            get { return datum; }
            set
            {
                datum = value;
            }
        }

        private void SolarniPaneliGrafik(object sender, RoutedEventArgs e)
        {
            if (datum == null)
            {
                MessageBox.Show("Izaberite datum", "Upozorenje", MessageBoxButton.OK);
                return;
            }

            SeriesCollection.Clear();

            Izvestaji context = new Izvestaji();

            int[] niz_intova = new int[1500];
            int brojac_labela = 0;
            ChartValues<double> vrednosti = new ChartValues<double>();

            foreach (var item in context.SolarniPaneli.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    niz_intova[brojac_labela++] = item.ID;
                    vrednosti.Add(item.Snaga);
                }
            }
            Labele = niz_intova;

            SeriesCollection.Add(new LineSeries
            {
                Title = "Solarni Paneli Graf",
                Values = vrednosti,
                /* LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                 PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                 PointGeometrySize = 50,
                 PointForeground = Brushes.Gray*/
            });

        }

        private void BaterijaGrafik(object sender, RoutedEventArgs e)
        {
            if (datum == null)
            {
                MessageBox.Show("Izaberite datum", "Upozorenje", MessageBoxButton.OK);
                return;
            }

            SeriesCollection.Clear();

            Izvestaji context = new Izvestaji();

            int[] niz_intova = new int[1500];
            int brojac_labela = 0;
            ChartValues<double> vrednosti = new ChartValues<double>();

            foreach (var item in context.Baterije.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    niz_intova[brojac_labela++] = item.ID;
                    vrednosti.Add(item.Snaga);
                }
            }
            Labele = niz_intova;

            SeriesCollection.Add(new LineSeries
            {
                Title = "Baterija Graf",
                Values = vrednosti,
                /* LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                 PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                 PointGeometrySize = 50,
                 PointForeground = Brushes.Gray*/
            });

        }

        private void PotrosaciGrafik(object sender, RoutedEventArgs e)
        {
            if (datum == null)
            {
                MessageBox.Show("Izaberite datum", "Upozorenje", MessageBoxButton.OK);
                return;
            }

            SeriesCollection.Clear();

            Izvestaji context = new Izvestaji();

            int[] niz_intova = new int[1500];
            int brojac_labela = 0;
            ChartValues<double> vrednosti = new ChartValues<double>();

            foreach (var item in context.Potrosaci.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    niz_intova[brojac_labela++] = item.ID;
                    vrednosti.Add(item.Snaga);
                }
            }
            Labele = niz_intova;

            SeriesCollection.Add(new LineSeries
            {
                Title = "Potrosaci Graf",
                Values = vrednosti,
                /* LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                 PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                 PointGeometrySize = 50,
                 PointForeground = Brushes.Gray*/
            });

        }

        private void ElektrodistribucijaGrafik(object sender, RoutedEventArgs e)
        {
            if (datum == null)
            {
                MessageBox.Show("Izaberite datum", "Upozorenje", MessageBoxButton.OK);
                return;
            }

            SeriesCollection.Clear();

            Izvestaji context = new Izvestaji();

            int[] niz_intova = new int[1500];
            int brojac_labela = 0;
            ChartValues<double> vrednosti = new ChartValues<double>();

            foreach (var item in context.Elektrodistribucije.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    niz_intova[brojac_labela++] = item.ID;
                    vrednosti.Add(item.Snaga);
                }
            }
            Labele = niz_intova;

            SeriesCollection.Add(new LineSeries
            {
                Title = "Elektrodistribucija Graf",
                Values = vrednosti,
                /* LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                 PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                 PointGeometrySize = 50,
                 PointForeground = Brushes.Gray*/
            });

        }
    }
}
