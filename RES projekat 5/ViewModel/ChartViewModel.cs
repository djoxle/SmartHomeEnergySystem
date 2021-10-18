using LiveCharts;
using LiveCharts.Wpf;
using PomocnaBiblioteka;
using RES_projekat_5.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RES_projekat_5.ViewModel
{
    [ExcludeFromCodeCoverage] //Deo UI-a
    public class ChartViewModel : BindableBase
    {
        /*public SeriesCollection seriescollection;
        public int[] labele;
        
        private Func<int, string> yosa;
        

        public MyICommand SolarniPaneliGrafik { get; set; }

        public MyICommand BaterijaGrafik { get; set; }

        public MyICommand PotrosaciGrafik { get; set; }

        public MyICommand ElektrodistribucijaGrafik { get; set; }

        private DateTime datum;*/

        public ChartViewModel()
        {
            /*
             {
                 new LineSeries
                 {
                     Title = "Series 1",
                     Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                 },
                 new LineSeries
                 {
                     Title = "Series 2",
                     Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                     PointGeometry = null
                 },
                 new LineSeries
                 {
                     Title = "Series 3",
                     Values = new ChartValues<double> { 4,2,7,2,7 },
                     PointGeometry = DefaultGeometries.Square,
                     PointGeometrySize = 15
                 }
             };
             
            SeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> {5, 3, 2, 4},
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });                        
             */

            //SeriesCollection series = new SeriesCollection();           

            //Labele = new int[90];

           // YOsa = value => value.ToString("F");

            //Izvestaji context = new Izvestaji();



           // SolarniPaneliGrafik = new MyICommand(PaneliGraf, MozePaneliGraf);

            /*ElektrodistribucijaGrafik = new MyICommand(DistribucijaGraf);

            BaterijaGrafik = new MyICommand(BaterijaGraf);

            PotrosaciGrafik = new MyICommand(PotrosaciGraf);*/

        }

       /* public SeriesCollection SeriesCollection
        {
            set
            {
                seriescollection = value;
                OnPropertyChanged("SeriesCollection");
            }
        }

        public int[] Labele
        {
            get { return labele; }
            set
            {
                labele = value;
                OnPropertyChanged("Labele");
            }
        }

        private Func<int, string> YOsa
        {
            get { return yosa; }
            set
            {
                yosa = value;
                OnPropertyChanged("YOsa");
            }
        }

        public DateTime Datum
        {
            get { return datum; }
            set
            {
                datum = value;
                //OnPropertyChanged("Datum");

                SolarniPaneliGrafik.RaiseCanExecuteChanged();

              /*  ElektrodistribucijaGrafik.RaiseCanExecuteChanged();

                BaterijaGrafik.RaiseCanExecuteChanged();

                PotrosaciGrafik.RaiseCanExecuteChanged();*/
       /*     }
        }

        public bool MozePaneliGraf()
        {
            return datum != null;
        }

        private void PaneliGraf()
        {
            Izvestaji context = new Izvestaji();

            SeriesCollection serija = new SeriesCollection();

            int[] niz_intova = new int[1500];
            int brojac_labela = 0;
            ChartValues<double> vrednosti = new ChartValues<double>();

            foreach(var item in context.SolarniPaneli.Where(x => true).ToList())
            {
                if (item.Datum.Date == datum.Date)
                {
                    niz_intova[brojac_labela++] = item.ID;
                    vrednosti.Add(item.Snaga);
                }
            }
            Labele = niz_intova;

            serija.Add(new LineSeries
            {
                Title = "Solarni Paneli Graf",
                Values = vrednosti,
               /* LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray*/
         /*   });

            SeriesCollection = serija;
        }*/

    }
}
