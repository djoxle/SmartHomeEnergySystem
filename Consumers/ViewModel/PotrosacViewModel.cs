using Consumers.Model;
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

namespace Consumers.ViewModel
{
    [ExcludeFromCodeCoverage] //Deo UI-a
    public class PotrosacViewModel : BindableBase
    {
        public static int brojac = 0;   //tako se radi

        public static ObservableCollection<Potrosac> Potrosaci { get; set; }

        public MyICommand DodajCommand { get; set; }

        public MyICommand ObrisiCommand { get; set; }

        public MyICommand UpaliUgasi { get; set; }

        //Potrebno je radi brisanja i omogucavanja brisanja.
        private Potrosac izabraniPotrosac;

        public List<string> TipPotrosaca { get; set; }
        public string tip_potrosaca { get; set; }
        private int snaga_po_tipu;

        public List<int> PotrosnjaPotrosaca;

        public PotrosacViewModel()
        {
            Potrosaci = new ObservableCollection<Potrosac>();

            DodajCommand = new MyICommand(Dodaj);

            ObrisiCommand = new MyICommand(Obrisi, MozeObrisi);

            UpaliUgasi = new MyICommand(PaliGasi, Moze_UpaliUgasi);


            TipPotrosaca = new List<string>() { "Racunar", "Sijalica", "Frizider", "Televizor" };

            PotrosnjaPotrosaca = new List<int>() { -80, -100 , -1000, -300 };

            Povezivanje();
        }

        public Potrosac IzabraniPotrosac
        {
            get { return izabraniPotrosac; }

            set
            {
                izabraniPotrosac = value;

                ObrisiCommand.RaiseCanExecuteChanged();

                UpaliUgasi.RaiseCanExecuteChanged();
            }
        }

        public bool Moze_UpaliUgasi()
        {
            return IzabraniPotrosac != null;
        }

        public void PaliGasi()
        {
            foreach(Potrosac p in Potrosaci)
            {
                if (p == IzabraniPotrosac)
                {
                    if (p.Upaljen == true)
                    {
                        p.Upaljen = false;
                    }
                    else
                    {
                        p.Upaljen = true;
                    }
                }
            }
        }

        public void Gasi()
        {
            foreach (Potrosac p in Potrosaci)
            {
                if (p == IzabraniPotrosac)
                {
                    p.Upaljen = false;
                }
            }
        }

        public bool MozeObrisi()
        {
            return IzabraniPotrosac != null;
        }

        public void Obrisi()
        {
            Potrosac s = izabraniPotrosac;

            Potrosaci.Remove(s);
        }

        private void Dodaj()
        {
            if (tip_potrosaca != null)
            {
                if (tip_potrosaca.Equals(TipPotrosaca[0]))
                {
                    snaga_po_tipu = PotrosnjaPotrosaca[0];
                }
                else if (tip_potrosaca.Equals(TipPotrosaca[1]))
                {
                    snaga_po_tipu = PotrosnjaPotrosaca[1];
                }
                else if (tip_potrosaca.Equals(TipPotrosaca[2]))
                {
                    snaga_po_tipu = PotrosnjaPotrosaca[2];
                }
                else if (tip_potrosaca.Equals(TipPotrosaca[3]))
                {
                    snaga_po_tipu = PotrosnjaPotrosaca[3];
                }

                Potrosaci.Add(new Potrosac() { Ime = tip_potrosaca, Potrosnja = snaga_po_tipu, ID = ++brojac, Upaljen = true });
            }
            else
            {
                MessageBox.Show("Morate izabrati tip solarnog panela.");
            }
        }

        private void Povezivanje()
        {
           
            double snaga = 0;

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = new TcpClient("localhost", 37011);

                    NetworkStream stream = tcpClient.GetStream();

                    foreach (Potrosac p in Potrosaci)
                    {
                       snaga += p.Potrosnja / 10;       //olaksano da ne uvodimo sinhroni sat
                    }

                    byte[] lista_bajtova = BitConverter.GetBytes(snaga);
                    stream.Write(lista_bajtova, 0, lista_bajtova.Length);

                    stream.Close();
                    tcpClient.Close();
                        
                    Thread.Sleep(1000);
                }
            });
            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

    }
}
