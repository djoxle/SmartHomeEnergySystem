using Battery.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Battery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    [ExcludeFromCodeCoverage] //Deo UI-a
    public partial class MainWindow : Window
    {

        public BindingList<Baterija> Baterije { get; set; }

        public DataGrid data;

     
        public MainWindow()
        {
            Baterije = new BindingList<Baterija>() { new Baterija() { ID = 1, Ime = "Baterija", Kapacitet = 0, MaksimalnaSnaga = 540 } };

           

            DataContext = this;
            InitializeComponent();
            
        }


        public double PromenaKapaciteta
        {
            get { return 9; }

            set
            {
                Baterije[0].Kapacitet += value;

                this.Dispatcher.Invoke(() =>
                {
                    dataGridKosarkasi.Items.Refresh();
                }
                );
                
            }
        }


    }
}
