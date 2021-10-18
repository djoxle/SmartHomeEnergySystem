using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RES_projekat_5.Pomocna_Vreme
{
    
    public class Vreme
    {
        private int sekunde;
        private int minuti;
        private int sati;
        private DateTime datum;
        private static readonly object objekat = new object();          //Sluzi za Singleton - Design Pattern
        private static Vreme instanca = null;

        public int Sekunde
        {
            get {

                if (sekunde == 60)
                {
                    sekunde = 0;
                    minuti += 1;
                }

                return sekunde;

            }
            set { sekunde = value; }
        }

        public int Minuti
        {
            get
            {
                if (minuti >= 60)
                {
                    minuti = 0;
                    Sati += 1;
                }
                return minuti;
            }
            set {                   
                minuti = value;
            }
        }

        public int Sati
        {
            get {

                if (sati == 24)
                {
                    sati = 0;
                    Datum.AddDays(1);
                }

                return sati;

            }
            set { sati = value; }
        }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }


        [ExcludeFromCodeCoverage]
        public static Vreme Konstruktor            //Singleton
        {
            get
            {
                lock (objekat)
                {
                    if (instanca != null)
                    {
                        return instanca;
                    }
                    else
                    {
                        instanca = new Vreme(0, 0, 0);
                        return instanca;
                    }
                }
            }

            private set { }
        }

        public Vreme(int sekunde, int minuti, int sati)
        {
            if(sekunde<= 60 && sekunde >= 0)
            {
                this.sekunde = sekunde;
            }
            else
            {
                throw new ArgumentException("Seconds must be in 0-60 range!");
            }
            if(minuti<= 60 && minuti >= 0)
            {
                this.minuti = minuti;
            }
            else
            {
                throw new ArgumentException("Minuts must be in 0-60 range!");
            }
            if(sati<=24 && sati>=0)
            {
                this.sati = sati;
            }
            else
            {
                throw new ArgumentException("Hours must be in 0-24 range!");
            }
            
        }

        [ExcludeFromCodeCoverage]
        public int[] CitanjeXML()
        {
            int[] retVal = new int[3];
            string path = AppDomain.CurrentDomain.BaseDirectory + "/.." + "/.." + "/.." + @"\Pomocna_Vreme\XMLFile.xml";        //
            XmlReader reader = XmlReader.Create(path);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Sekunde")
                {
                    retVal[0] = Convert.ToInt32(reader.ReadString());
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "Minuti")
                {
                    retVal[1] = Convert.ToInt32(reader.ReadString());
                }
                else if (reader.NodeType == XmlNodeType.Element && reader.Name == "Sati")
                {
                    retVal[2] = Convert.ToInt32(reader.ReadString());
                    break;
                }
            }

            return retVal;
        }

      /*  public override string ToString()
        {
            string sati = "";
            string sekunde = "";
            string minuti = "";

            if (Sati < 10)
            {
                sati = "0" + Sati.ToString();
            }
            else if (Sati == 0)
            {
                sati = "00";
            }
            else if (Sati >= 10)
            {
                sati = Sati.ToString();
            }
            if (Sekunde == 0)
            {
                sekunde = "00";
            }
            else
            {
                sekunde = "30";
            }
            if (Minuti == 0)
            {
                minuti = "00";
            }
            else
            {
                minuti = Minuti.ToString();
            }

            return Datum.ToShortDateString() + " " + sati + ":" + minuti + ":" + sekunde + " " + AM_PM;
        }*/
    }
}
