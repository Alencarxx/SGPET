using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using SGPET.View;

namespace SGPET.ViewModel
{
    public class ToolBarViewModel
    {
        public ToolBarViewModel()
        {
            HomeCmd = new RelayCommand<object>(ExecuteHomeCmd, null);
            ClienteCmd = new RelayCommand<object>(ExecuteClienteCmd, null);
            ContratoCmd = new RelayCommand<object>(ExecuteContratoCmd, null);
        }

        public ICommand HomeCmd { get; internal set; }
        public ICommand ClienteCmd { get; internal set; }
        public ICommand ContratoCmd { get; internal set; }


        public void ExecuteHomeCmd(object parameter)
        {

        }

        public void ExecuteClienteCmd(object parameter)
        {
            var clientesWidnow = new ClientesWindow();
            clientesWidnow.ShowDialog();
        }

        public void ExecuteContratoCmd(object parameter)
        {
            var contratosWidnow = new ContratosWindow();
            contratosWidnow.ShowDialog();
        }
    }
}

