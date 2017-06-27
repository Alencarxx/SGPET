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
using System.Windows.Shapes;

namespace SGPET.View
{
    /// <summary>
    /// Interaction logic for AgendamentoWindow.xaml
    /// </summary>
    public partial class AgendamentoWindow : Window
    {
        public AgendamentoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource agendamentoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("agendamentoViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // agendamentoViewSource.Source = [generic data source]
            SGPET.SGPETDADOSDataSet sGPETDADOSDataSet = ((SGPET.SGPETDADOSDataSet)(this.FindResource("sGPETDADOSDataSet")));
            // Load data into the table Agendamentos. You can modify this code as needed.
            SGPET.SGPETDADOSDataSetTableAdapters.AgendamentosTableAdapter sGPETDADOSDataSetAgendamentosTableAdapter = new SGPET.SGPETDADOSDataSetTableAdapters.AgendamentosTableAdapter();
            sGPETDADOSDataSetAgendamentosTableAdapter.Fill(sGPETDADOSDataSet.Agendamentos);
            System.Windows.Data.CollectionViewSource agendamentosViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("agendamentosViewSource")));
            agendamentosViewSource.View.MoveCurrentToFirst();
        }

        private void agendamentosDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void agendamentosDataGrid_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
