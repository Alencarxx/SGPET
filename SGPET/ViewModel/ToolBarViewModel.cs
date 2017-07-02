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
            ProdutoCmd = new RelayCommand<object>(ExecuteProdutoCmd, null);
            VendaCmd = new RelayCommand<object>(ExecuteVendaCmd, null);
            FinanceiroCmd = new RelayCommand<object>(ExecuteFinanceiroCmd, null);
            SobreCmd = new RelayCommand<object>(ExecuteSobreCmd, null);
        }

        public ICommand HomeCmd { get; internal set; }
        public ICommand ClienteCmd { get; internal set; }
        public ICommand ContratoCmd { get; internal set; }
        public ICommand AgendamentoCmd { get; internal set; }
        public ICommand VacinaCmd { get; internal set; }
        public ICommand ProdutoCmd { get; internal set; }
        public ICommand VendaCmd { get; internal set; }
        public ICommand FinanceiroCmd { get; internal set; }
        public ICommand SobreCmd { get; internal set; }

        private void ExecuteHomeCmd(object parameter)
        {

        }

        private void ExecuteClienteCmd(object parameter)
        {
            var clientesWindow = new ClientesWindow();
            clientesWindow.ShowDialog();
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

        private void ExecuteProdutoCmd(object parameter)
        {
            var produtoWidnow = new ProdutoWindow();
            produtoWidnow.ShowDialog();
        }

        private void ExecuteVendaCmd(object parameter)
        {
            var vendaWidnow = new VendaWindow();
            vendaWidnow.ShowDialog();
        }

        private void ExecuteFinanceiroCmd(object parameter)
        {
            var financeiroWidnow = new FinanceiroWindow();
            financeiroWidnow.ShowDialog();
        }


        private void ExecuteSobreCmd(object parameter)
        {
            var sobreWidnow = new SobreWindow();
            sobreWidnow.ShowDialog();
        }

    }
}

