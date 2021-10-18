using Consumers.ViewModel;
using PomocnaBiblioteka;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumers
{
    [ExcludeFromCodeCoverage] //Deo UI-a
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private PotrosacViewModel potrosacViewModel;
        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            potrosacViewModel = new PotrosacViewModel();

            NavCommand = new MyICommand<string>(OnNav);

            currentViewModel = potrosacViewModel;
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
            CurrentViewModel = potrosacViewModel;
        }

    }
}
