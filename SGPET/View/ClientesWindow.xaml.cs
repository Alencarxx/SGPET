using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using DevExpress.Xpf.Core;
using log4net;

namespace SGPET.View
{
    /// <summary>
    /// Interaction logic for ClientesWindow.xaml
    /// </summary>
    public partial class ClientesWindow : DXWindow
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string _strConexao = "";
        SqlConnection _conn;

        public ClientesWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _strConexao = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            VincularDados();
            //Mocks.SGPET_SGPETDADOSDataSet_34_162968216 sGPETDADOSDataSet = ((Mocks.SGPET_SGPETDADOSDataSet_34_162968216)(this.FindResource("sGPETDADOSDataSet")));
            // TODO: Add code here to load data into the table Cliente.
            // This code could not be generated, because the sGPETDADOSDataSetClienteTableAdapter.Fill method is missing, or has unrecognized parameters.
            SGPET.SGPETDADOSDataSetTableAdapters.ClienteTableAdapter sGPETDADOSDataSetClienteTableAdapter = new SGPET.SGPETDADOSDataSetTableAdapters.ClienteTableAdapter();
            System.Windows.Data.CollectionViewSource clienteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clienteViewSource")));
            clienteViewSource.View.MoveCurrentToFirst();
        }

        private void VincularDados()
        {
            try
            {
                _conn = new SqlConnection(_strConexao);
                _conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Cliente", _conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);

                da.Fill(dt);
                //clientesDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Log.Error("Erro VincularDados: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if () return; //var date1 = chegadaDatePicker?.SelectedDate.Value.Date;
                //var date2 = saidaDatePicker?.SelectedDate.Value.Date;

                _conn = new SqlConnection(_strConexao);
                _conn.Open();

               

                //string sql =
                //    "INSERT INTO Cliente (Nome, Endereco, Telefone, Animal, Desde) VALUES('" +
                //    nomeTextBox.Text + "','" + enderecoTextBox.Text + "','" + telefoneTextBox.Text + "','" +
                //    animalTextBox.Text + "', '" + desdeTextBox.Text + "' )";

                SqlCommand comm = new SqlCommand("", _conn);
                //comm.Parameters.AddWithValue("@value", date1);
                //comm.Parameters.AddWithValue("@value2", date2);
                comm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Log.Error("Erro VincularDados: " + ex.Message);
            }
            finally
            {
                _conn.Close();
                VincularDados();
            }
        }
    }
}
