using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
using DevExpress.Xpf.Core;
using log4net;

namespace SGPET.View
{
    /// <summary>
    /// Interaction logic for ContratosWindow.xaml
    /// </summary>
    public partial class ContratosWindow : DXWindow
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string _strConexao = "";
        SqlConnection _conn;

        public ContratosWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _strConexao = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            VincularDados();
            // TODO: Add code here to load data into the table Contratos.
            // This code could not be generated, because the sGPETDADOSDataSetContratosTableAdapter.Fill method is missing, or has unrecognized parameters.
            SGPET.SGPETDADOSDataSetTableAdapters.ContratosTableAdapter sGPETDADOSDataSetContratosTableAdapter = new SGPET.SGPETDADOSDataSetTableAdapters.ContratosTableAdapter();
            System.Windows.Data.CollectionViewSource contratosViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contratosViewSource")));
            contratosViewSource.View.MoveCurrentToFirst();
        }

        private void VincularDados()
        {
            try
            {
                _conn = new SqlConnection(_strConexao);
                _conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Contrato", _conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);

                da.Fill(dt);
                contratoDataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Log.Error("Erro VincularDados: " + ex.Message);
            }
            finally
            {
                _conn.Close();
                LimparTela();
            }
        }

        private void contratoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contratoDataGrid.SelectedCells.Count > 0)
            {
                codigoTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["Codigo"].ToString();
                nomeTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["Nome"].ToString();
                cPFTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["CPF"].ToString();
                rGTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["RG"].ToString();
                enderecoTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["Endereco"].ToString();
                telefoneTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["Telefone"].ToString();
                emailTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["Email"].ToString();
                animalTextBox.Text = ((DataRowView)contratoDataGrid.SelectedItem).Row["Animal"].ToString();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nomeTextBox.Text == "" && nomeTextBox.Text == "" &&
                    cPFTextBox.Text == "" && cPFTextBox.Text == "" && enderecoTextBox.Text == "" && telefoneTextBox.Text == "" &&
                    emailTextBox.Text == "" && animalTextBox.Text == "") return;

                _conn = new SqlConnection(_strConexao);
                _conn.Open();

                string sql = "INSERT INTO Contrato (Nome, CPF, RG, Endereco, Telefone, Email, Animal) VALUES('" +
                    nomeTextBox.Text + "','" + cPFTextBox.Text + "','" + rGTextBox.Text + "','" +
                    enderecoTextBox.Text + "', '" + telefoneTextBox.Text + "', '" + emailTextBox.Text + "', '" + animalTextBox.Text + "' )";

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
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nomeTextBox.Text == "" && nomeTextBox.Text == "" &&
                    cPFTextBox.Text == "" && cPFTextBox.Text == "" && enderecoTextBox.Text == "" && telefoneTextBox.Text == "" &&
                    emailTextBox.Text == "" && animalTextBox.Text == "") return;


                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Deleção", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();
                    var id = codigoTextBox.Text;
                    SqlCommand comm = new SqlCommand("DELETE FROM Contrato WHERE Codigo = " + id, _conn);
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
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nomeTextBox.Text == "" && nomeTextBox.Text == "" &&
                    cPFTextBox.Text == "" && cPFTextBox.Text == "" && enderecoTextBox.Text == "" && telefoneTextBox.Text == "" &&
                    emailTextBox.Text == "" && animalTextBox.Text == "") return;

                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Atualização", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();

                    var stringsql = "UPDATE Contrato SET Nome='" + nomeTextBox.Text + "',CPF='" +
                                    cPFTextBox.Text + "',RG='" + rGTextBox.Text + "',Endereco='" +
                                    enderecoTextBox.Text + "',Telefone='" + telefoneTextBox.Text + "',Email='" + emailTextBox.Text + "',Animal='" + animalTextBox.Text + "' WHERE Codigo = " + codigoTextBox.Text;

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
            }
        }

        private void LimparTela()
        {
            codigoTextBox.Clear();
            nomeTextBox.Clear();
            cPFTextBox.Clear();
            rGTextBox.Clear();
            enderecoTextBox.Clear();
            telefoneTextBox.Clear();
            emailTextBox.Clear();
            animalTextBox.Clear();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparTela();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
