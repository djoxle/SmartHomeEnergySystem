using PomocnaBiblioteka;
using Solar_panel_s_.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Solar_panel_s_
{
    [ExcludeFromCodeCoverage] //Deo UI-a

    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private SolarniPaneliViewModel solarnipanelViewModel;
        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            solarnipanelViewModel = new SolarniPaneliViewModel();

            NavCommand = new MyICommand<string>(OnNav);

            currentViewModel = solarnipanelViewModel;

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
            CurrentViewModel = solarnipanelViewModel;
        }

        

    }
}
