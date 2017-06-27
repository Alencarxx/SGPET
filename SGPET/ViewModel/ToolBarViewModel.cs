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
            AgendamentoCmd = new RelayCommand<object>(ExecuteAgendamentoCmd, null);
            VacinaCmd = new RelayCommand<object>(ExecuteVacinaCmd, null);
        }

        public ICommand HomeCmd { get; internal set; }
        public ICommand ClienteCmd { get; internal set; }
        public ICommand ContratoCmd { get; internal set; }
        public ICommand AgendamentoCmd { get; internal set; }
        public ICommand VacinaCmd { get; internal set; }
        


        private void ExecuteHomeCmd(object parameter)
        {

        }

        private void ExecuteClienteCmd(object parameter)
        {
            var clientesWidnow = new ClientesWindow();
            clientesWidnow.ShowDialog();
        }

        private void ExecuteContratoCmd(object parameter)
        {
            var contratosWidnow = new ContratosWindow();
            contratosWidnow.ShowDialog();
        }

        private void ExecuteAgendamentoCmd(object parameter)
        {
            var agendamentoWidnow = new AgendamentoWindow();
            agendamentoWidnow.ShowDialog();
        }

        private void ExecuteVacinaCmd(object parameter)
        {
            var vacinaWidnow = new VacinaWindow();
            vacinaWidnow.ShowDialog();
        }

        
    }
}

