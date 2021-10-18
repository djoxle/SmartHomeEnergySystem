using System;
using System.Collections.Generic;
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

namespace Utility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string protok_struje = "";

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();            
        }

        public string ProtokStruje
        {
            get { return protok_struje; }
            set {
                this.Dispatcher.Invoke(() =>
                {
                    Protok_Struje.Text = value;
                });
                protok_struje = value;}
        }

        private double cena = 7.392;

        public double Cena
        {
            get { return cena; }

           private set { cena = value; }
        }

    }
}
