using PomocnaBiblioteka;
using RES_projekat_5.Model;
using RES_projekat_5.Pomocna_Vreme;
using RES_projekat_5.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Battery;
using Solar_panel_s_;
using Utility;
using Consumers;
using System.Diagnostics.CodeAnalysis;

namespace RES_projekat_5
{
    [ExcludeFromCodeCoverage] //Deo UI-a
    public class MainWindowViewModel : BindableBase
    {

        public MyICommand<string> NavCommand { get; private set; }

        private ChartViewModel chartViewModel;

        private ShesViewModel shesViewModel;

        private BindableBase currentViewModel;

        private int sati;
        private int minuti;
        private int sekunde;

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);

            chartViewModel = new ChartViewModel();
            shesViewModel = new ShesViewModel();

            currentViewModel = chartViewModel;

            RacunanjeVremena();            //Vreme koje ce sluziti za upis svih konekcija u bazu.

            solarniPaneliKonekcija();

            potrosaciKonekcija();

            baterijaPovezivanje();

            elektrodistribucijaKonekcija();
        }       

        public int Sati
        {
            get { return sati; }
            set
            {
                if (sati != value)
                {
                    sati = value;
                    OnPropertyChanged("Sati");
                }
            }
        }

        public int Minuti
        {
            get { return minuti; }
            set
            {
                if (minuti != value)
                {
                    minuti = value;
                    OnPropertyChanged("Minuti");
                }
            }
        }

        public int Sekunde
        {
            get { return sekunde; }
            set
            {
                if (sekunde != value)
                {
                    sekunde = value;
                    OnPropertyChanged("Sekunde");
                }
            }
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }       

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "grafik":
                    CurrentViewModel = chartViewModel;
                    break;
                case "izvestaj":
                    CurrentViewModel = shesViewModel;
                    break;
            }
        }

        #region Konekcija

        /// <summary>
        /// Ova metoda ce praviti izvestaje na svakih sat vremena. Inace ce biti previse podataka za bazu.
        /// Tolika kolicina podataka nece biti potrebna za prikaz na grafiku. Svakih sat vremena praviti izvestaj je optimum.
        /// </summary>
        private void RacunanjeVremena()
        {           
            Thread nit = new Thread(() =>
            {
                
                int[] podaci = Vreme.Konstruktor.CitanjeXML();

                //Sluzi za uvecavanje
                int sekunde = podaci[0];
                int minuti = podaci[1];
                int sati = podaci[2];
                Vreme.Konstruktor.Datum = DateTime.Now;

                Sati = 0;
                Minuti = 0;
                Sekunde = 0;

                while (true)
                {
                    Vreme.Konstruktor.Sekunde += sekunde;
                    Sekunde = Vreme.Konstruktor.Sekunde;

                    Vreme.Konstruktor.Minuti += minuti;
                    Minuti = Vreme.Konstruktor.Minuti;

                    Sati = Vreme.Konstruktor.Sati;

                    Thread.Sleep(1000);
                }
            });
            nit.IsBackground = true;
            nit.Start();
        }

        private void solarniPaneliKonekcija()
        {
            Solar_panel_s_.MainWindow mainWindow = new Solar_panel_s_.MainWindow();
            mainWindow.Show();
            Izvestaji context = new Izvestaji();

            var tcp = new TcpListener(IPAddress.Any, 22222);
            tcp.Start();
            double incomming;
            int brojac = 0;     //za id-eve

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                        var tcpClient = tcp.AcceptTcpClient();

                        NetworkStream stream = tcpClient.GetStream();
                        
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        incomming = BitConverter.ToDouble(bytes, 0);

                        if (incomming != 0)
                        {
                            context.SolarniPaneli.Add(new ProizvodnjaSolarnihPanela() { ID = ++brojac, Datum = DateTime.Now, Snaga = incomming });
                            context.SaveChanges();
                        }                  
                }
            });
            listeningThread.IsBackground = true;
            listeningThread.Start();
        }


        private void potrosaciKonekcija()
        {
            Consumers.MainWindow mainWindow = new Consumers.MainWindow();
            mainWindow.Show();

            Izvestaji context = new Izvestaji();
            var tcp = new TcpListener(IPAddress.Any, 37011);
            tcp.Start();
            double incomming;
            int brojac = 0;     //za id-eve

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                        var tcpClient = tcp.AcceptTcpClient();

                        NetworkStream stream = tcpClient.GetStream();

                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);                        
                        incomming = BitConverter.ToDouble(bytes, 0);

                        if (incomming != 0)
                        {
                            context.Potrosaci.Add(new PotrosnjaPotrosaca() { ID = ++brojac, Datum = Vreme.Konstruktor.Datum, Snaga = incomming });
                            context.SaveChanges();
                        }

                }
            });
            listeningThread.IsBackground = true;
            listeningThread.Start();
        }


        public void baterijaPovezivanje()
        {
            int brojac = 0;
            Battery.MainWindow mainWindow = new Battery.MainWindow();
            mainWindow.Show();

            Izvestaji context = new Izvestaji();

            Thread nit = new Thread(() =>
            {

                while (true)
                {
                    if (Vreme.Konstruktor.Sati >= 3 && Vreme.Konstruktor.Sati < 6)
                    {
                        mainWindow.PromenaKapaciteta = mainWindow.Baterije[0].MaksimalnaSnaga / 100;

                            context.Baterije.Add(new EnergijaIzBaterije() { ID = ++brojac, Datum = DateTime.Now, Snaga = mainWindow.Baterije[0].MaksimalnaSnaga / 80 });
                            context.SaveChanges();
                    }
                    else if (Vreme.Konstruktor.Sati >= 14 && Vreme.Konstruktor.Sati < 17)
                    {
                        mainWindow.PromenaKapaciteta = (-1) * mainWindow.Baterije[0].MaksimalnaSnaga / 90;

                            context.Baterije.Add(new EnergijaIzBaterije() { ID = ++brojac, Datum = DateTime.Now, Snaga = (-1) * mainWindow.Baterije[0].MaksimalnaSnaga / 90 });
                            context.SaveChanges();
                    }

                    Thread.Sleep(1000);
                }
            });
            nit.IsBackground = false;
            nit.Start();
        }



      /*  private void baterijaKonekcija()
        {
              double incomming;
              int brojac = 0;     //za id-eve
              string poruka = " ";
              var sendingThread = new Thread(() =>
              {
                  while (true)
                  {
                      TcpClient tcpClient = new TcpClient("localhost", 11000);

                      NetworkStream stream = tcpClient.GetStream();

                      if (Vreme.Konstruktor.Sati >= 3 && Vreme.Konstruktor.Sati < 6)
                      {
                          poruka = "Puni";
                      }
                      else if (Vreme.Konstruktor.Sati >= 14 && Vreme.Konstruktor.Sati < 17)
                      {
                          poruka = "Prazni";
                      }


                      Byte[] data = System.Text.Encoding.ASCII.GetBytes(poruka);
                      stream.Write(data, 0, data.Length);

                      byte[] bytes = new byte[1024];
                      int i = stream.Read(bytes, 0, bytes.Length);
                      incomming = BitConverter.ToDouble(bytes, 0);

                      if (incomming != 0)
                      {
                          Izvestaji izvestaji = Izvestaji.Konstruktor;
                          izvestaji.Baterije.Add(new EnergijaIzBaterije() { ID = ++brojac, Datum =  Vreme.Konstruktor.Datum, Snaga = incomming });
                          izvestaji.SaveChanges();
                      }

                      stream.Close();
                      tcpClient.Close();

                      Thread.Sleep(1000);

                  }
              });
              sendingThread.IsBackground = true;
              sendingThread.Start();
        }*/


        private void elektrodistribucijaKonekcija()
        {

            int brojac = 1;
            double solarni_paneli = 0;
            double baterija = 0;
            double potrosaci = 0;
            double elektrodistribucija = 0;
            Utility.MainWindow mainWindow = new Utility.MainWindow();
            mainWindow.Show();
            Izvestaji context = new Izvestaji();
            
            Thread nit = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1500);

                    if (context.SolarniPaneli.Where(p => p.ID == brojac).ToList().Count == 0)
                    {
                        solarni_paneli = 0;
                    }
                    else
                    {
                        solarni_paneli = context.SolarniPaneli.Where(p => p.ID == brojac).ToList()[0].Snaga;
                    }

                    if (context.Baterije.Where(p => p.ID == brojac).ToList().Count == 0)
                    {
                        baterija = 0;
                    }
                    else
                    {
                        baterija = context.Baterije.Where(p => p.ID == brojac).ToList()[0].Snaga;
                    }

                    if (context.Potrosaci.Where(p => p.ID == brojac).ToList().Count == 0)
                    {
                        potrosaci = 0;
                    }
                    else
                    {
                        potrosaci = context.Potrosaci.Where(p => p.ID == brojac).ToList()[0].Snaga;
                    }                                                        

                    elektrodistribucija = solarni_paneli + baterija + potrosaci;

                    if (elektrodistribucija < 0)
                    {
                        mainWindow.ProtokStruje = "Proizvodnja je manja od potrosnje.";
                    }
                    else if (elektrodistribucija > 0)
                    {
                        mainWindow.ProtokStruje = "Proizvodnja je veca od potrosnje.";
                    }
                    else if (elektrodistribucija == 0)
                    {
                        mainWindow.ProtokStruje = "Optimalno";
                    }

                    context.Elektrodistribucije.Add(new SnagaElektrodistribucija() { ID = brojac, Cena = mainWindow.Cena, Datum = DateTime.Now, Snaga = elektrodistribucija });
                    context.SaveChanges();

                    brojac++;
                    solarni_paneli = 0;
                    baterija = 0;
                    potrosaci = 0;
                    elektrodistribucija = 0;
                }

            });
            nit.IsBackground = true;
            nit.Start();


            //var tcpClient = new TcpClient("localhost", 37013);

            //NetworkStream stream = tcpClient.GetStream();

            //Byte[] data = System.Text.Encoding.ASCII.GetBytes();
            //stream.Write(data, 0, data.Length);

            //short incomming;
            //byte[] bytes = new byte[1024];
            //int i = stream.Read(bytes, 0, bytes.Length);
            //incomming = Convert.ToInt16(System.Text.Encoding.ASCII.GetString(bytes, 0, i));

            //stream.Close();
            //tcpClient.Close();

            //return incomming;
        }

        #endregion
    }
}
