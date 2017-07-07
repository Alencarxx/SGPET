using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
          
        }

        private void macDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clienteDataGrid.SelectedCells.Count > 0)
            {
                codigoTextBox.Text = ((DataRowView)clienteDataGrid.SelectedItem).Row["Codigo"].ToString();
                nomeTextBox.Text = ((DataRowView)clienteDataGrid.SelectedItem).Row["Nome"].ToString();
                enderecoTextBox.Text = ((DataRowView)clienteDataGrid.SelectedItem).Row["Endereco"].ToString();
                telefoneTextBox.Text = ((DataRowView)clienteDataGrid.SelectedItem).Row["Telefone"].ToString();
                animalTextBox.Text = ((DataRowView)clienteDataGrid.SelectedItem).Row["Animal"].ToString();
                desdeTextBox.Text = ((DataRowView)clienteDataGrid.SelectedItem).Row["Desde"].ToString();
            }
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
                clienteDataGrid.ItemsSource = dt.DefaultView;
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
                _conn = new SqlConnection(_strConexao);
                _conn.Open();

                string sql =
                    "INSERT INTO Cliente (Nome, Endereco, Telefone, Animal, Desde) VALUES('" +
                    nomeTextBox.Text + "','" + enderecoTextBox.Text + "','" + telefoneTextBox.Text + "','" +
                    animalTextBox.Text + "', '" + desdeTextBox.Text + "' )";

                SqlCommand comm = new SqlCommand(sql, _conn);
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
                LimparTela();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if () return;

                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Atualização", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();
              
                    var stringsql = "UPDATE Cliente SET Nome='" + nomeTextBox.Text + "',Endereco='" +
                                    enderecoTextBox.Text + "',Telefone='" + telefoneTextBox.Text + "',Animal='" +
                                    animalTextBox.Text + "',Desde='" + desdeTextBox.Text + "' WHERE Codigo = " + codigoTextBox.Text;

                    SqlCommand comm = new SqlCommand(stringsql, _conn);
                    
                    comm.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Log.Error("Erro VincularDados: " + ex.Message);
            }
            finally
            {
                _conn.Close();
                VincularDados();
                LimparTela();
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if () return;


                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Deleção", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();
                    var id = codigoTextBox.Text;
                    SqlCommand comm = new SqlCommand("DELETE FROM Cliente WHERE Codigo = " + id, _conn);
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Erro VincularDados: " + ex.Message);
            }
            finally
            {
                _conn.Close();
                VincularDados();
                LimparTela();
            }
        }

        private void LimparTela()
        {
            codigoTextBox.Clear();
            nomeTextBox.Text = "";
            animalTextBox.Clear();
            enderecoTextBox.Clear();
            telefoneTextBox.Clear();
            desdeTextBox.Clear();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            codigoTextBox.Clear();
            nomeTextBox.Text = "";
            animalTextBox.Clear();
            enderecoTextBox.Clear();
            telefoneTextBox.Clear();
            desdeTextBox.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
