using PomocnaBiblioteka;
using Solar_panel_s_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Solar_panel_s_.ViewModel
{
    [ExcludeFromCodeCoverage] //Deo UI-a

    public class SolarniPaneliViewModel : BindableBase
    {
        public static int brojac = 0;   //tako se radi

        
        public static ObservableCollection<SolarniPanel> SolarniPaneli { get; set; }
        

        public MyICommand DodajCommand { get; set; }

        public MyICommand AzurirajSnagu { get; set; }

        public MyICommand ObrisiCommand { get; set; }

        //Potrebno je radi brisanja i omogucavanja brisanja.
        private SolarniPanel izabraniSolarniPanel;

        public List<string> TipSolarnogPanela { get; set; }
        public string tip_solarnog_panela { get; set; }

        public List<int> SnagaPoTipuSolarnogPanela { get; set; }
        public int snaga_po_tipu;

        private string textBox;
        private double jacina_sunca;

        public SolarniPaneliViewModel()
        {

            SolarniPaneli = new ObservableCollection<SolarniPanel>();


            DodajCommand = new MyICommand(Dodaj);

            AzurirajSnagu = new MyICommand(Azuriraj);

            ObrisiCommand = new MyICommand(Obrisi, MozeObrisi);

            TipSolarnogPanela = new List<string>() { "Monokristalni", "Polikristalni", "Thin-Film" };

            SnagaPoTipuSolarnogPanela = new List<int>() { 305, 295, 300 };

            var nit = new Thread(() =>

            {
                while (true)
                {
                    foreach(SolarniPanel solarniPanel in SolarniPaneli)
                    {
                        solarniPanel.GenerisanaSnaga += ((jacina_sunca/100) * (solarniPanel.MaksimalnaSnagaSolarnogPanela / 450));       //olaksano da ne uvodimo sinhroni sat
                    }

                    Thread.Sleep(1000);
                }
            }
            
            );
            nit.IsBackground = true;
            nit.Start();

            Povezivanje();
        }

        public string TextBox
        {
            get { return textBox; }
            set
            {
                if (textBox != value)
                {
                    textBox = value;
                    OnPropertyChanged("TextBox");
                }
            }
        }

        public SolarniPanel IzabraniSolarniPanel
        {
            get { return izabraniSolarniPanel; }

            set
            {
                izabraniSolarniPanel = value;

                ObrisiCommand.RaiseCanExecuteChanged();
            }
        }

        public void Azuriraj()
        {
            int provera = 0;
            if (Int32.TryParse(TextBox, out provera))
            {
                JacinaSunca = provera;
            }
            else
            {
                MessageBox.Show("Unesite ceo broj od 1 do 100.");
            }
        }

        public bool MozeObrisi()
        {
            return izabraniSolarniPanel != null;
        }

        public void Obrisi()
        {
            SolarniPanel s = izabraniSolarniPanel;

            SolarniPaneli.Remove(s);
        }

        private void Dodaj()
        {
            if (tip_solarnog_panela != null)
            {
                if (tip_solarnog_panela.Equals(TipSolarnogPanela[0]))
                {
                    snaga_po_tipu = SnagaPoTipuSolarnogPanela[0];
                }
                else if (tip_solarnog_panela.Equals(TipSolarnogPanela[1]))
                {
                    snaga_po_tipu = SnagaPoTipuSolarnogPanela[1];
                }
                else if (tip_solarnog_panela.Equals(TipSolarnogPanela[2]))
                {
                    snaga_po_tipu = SnagaPoTipuSolarnogPanela[2];
                }

                SolarniPaneli.Add(new SolarniPanel() { ID = ++brojac, ImeSolarnogPanela = "Solarni_Panel_" + brojac.ToString(), MaksimalnaSnagaSolarnogPanela = snaga_po_tipu, GenerisanaSnaga = 0, TipSolarnogPanelaProperty =  tip_solarnog_panela});
            }
            else
            {
                MessageBox.Show("Morate izabrati tip solarnog panela.");
            }
        }

        public double JacinaSunca
        {
            get { return jacina_sunca; }

            set
            {
                if (value > 100 || value < 1)
                {
                    MessageBox.Show("Jacina Sunca mora biti izmedju 1 i 100");
                }
                else
                {

                    jacina_sunca = value;
                }
            }
        }

        private void Povezivanje()
        {
            
            double snaga = 0;

            var sendingThread = new Thread(() =>
            {
                while (true)
                {
                    TcpClient tcpClient = new TcpClient("localhost", 22222);

                    NetworkStream stream = tcpClient.GetStream();
                      
                   foreach (SolarniPanel s in SolarniPaneli)
                   {
                            snaga += s.GenerisanaSnaga;
                   }


                    byte[] lista_bajtova = BitConverter.GetBytes(snaga);
                    stream.Write(lista_bajtova, 0, lista_bajtova.Length);

                    stream.Close();
                    tcpClient.Close();

                    Thread.Sleep(1000);

                }
            });
            sendingThread.IsBackground = true;
            sendingThread.Start();
        }
    }
}
