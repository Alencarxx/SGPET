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
using DevExpress.Xpf.Core;

namespace SGPET.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            HomePage homepage = new HomePage();
            grid2.Children.Clear();
            grid2.Children.Add(homepage);
        }

        private void Home_OnClick(object sender, RoutedEventArgs e)
        {
            HomePage homepage = new HomePage();
            grid2.Children.Clear();
            grid2.Children.Add(homepage);
        }

        private void Clientes_OnClick(object sender, RoutedEventArgs e)
        {
            ClientesPage clientespage = new ClientesPage();
            grid2.Children.Clear();
            grid2.Children.Add(clientespage);
        }

        private void Contratos_OnClick(object sender, RoutedEventArgs e)
        {
            ContratoPage contratopage = new ContratoPage();
            grid2.Children.Clear();
            grid2.Children.Add(contratopage);
        }

        private void Agendamentos_OnClick(object sender, RoutedEventArgs e)
        {
            AgendamentoPage agendamentop = new AgendamentoPage();
            grid2.Children.Clear();
            grid2.Children.Add(agendamentop);
        }

        private void Vacinas_OnClick(object sender, RoutedEventArgs e)
        {
            VacinaPage vacinapage = new VacinaPage();
            grid2.Children.Clear();
            grid2.Children.Add(vacinapage);
        }

        private void Produtos_OnClick(object sender, RoutedEventArgs e)
        {
            ProdutosPage produtopage = new ProdutosPage();
            grid2.Children.Clear();
            grid2.Children.Add(produtopage);
        }

        private void Vendas_OnClick(object sender, RoutedEventArgs e)
        {
            VendasPage vendaspage = new VendasPage();
            grid2.Children.Clear();
            grid2.Children.Add(vendaspage);
        }

        private void Financeiro_OnClick(object sender, RoutedEventArgs e)
        {
            FinanceiroPage financeiropage = new FinanceiroPage();
            grid2.Children.Clear();
            grid2.Children.Add(financeiropage);
        }

        private void Sobre_OnClick(object sender, RoutedEventArgs e)
        {
            SobrePage sobrepage = new SobrePage();
            grid2.Children.Clear();
            grid2.Children.Add(sobrepage);
        }
    }
}
