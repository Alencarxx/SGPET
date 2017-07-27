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
    /// Interaction logic for VacinaWindow.xaml
    /// </summary>
    public partial class VacinaWindow : DXWindow
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string _strConexao = "";
        SqlConnection _conn;

        public VacinaWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _strConexao = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            VincularDados();
        }

        private void VincularDados()
        {
            try
            {
                _conn = new SqlConnection(_strConexao);
                _conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Vacina", _conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);

                da.Fill(dt);
                vacinasDataGrid.ItemsSource = dt.DefaultView;
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

        private void vacinasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vacinasDataGrid.SelectedCells.Count > 0)
            {
                codigoTextBox.Text = ((DataRowView)vacinasDataGrid.SelectedItem).Row["Codigo"].ToString();
                animalTextBox.Text = ((DataRowView)vacinasDataGrid.SelectedItem).Row["Animal"].ToString();
                idadeTextBox.Text = ((DataRowView)vacinasDataGrid.SelectedItem).Row["Idade"].ToString();
                proprietarioTextBox.Text = ((DataRowView)vacinasDataGrid.SelectedItem).Row["Proprietario"].ToString();
                telefoneTextBox.Text = ((DataRowView)vacinasDataGrid.SelectedItem).Row["Telefone"].ToString();
                observacaoTextBox.Text = ((DataRowView)vacinasDataGrid.SelectedItem).Row["Observacao"].ToString();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (animalTextBox.Text == "" && proprietarioTextBox.Text == "" &&
                    idadeTextBox.Text == "" && telefoneTextBox.Text == "" && observacaoTextBox.Text == "") return;

                _conn = new SqlConnection(_strConexao);
                _conn.Open();

                string sql = "INSERT INTO Vacina (Animal, Idade, Proprietario, Telefone, Observacao) VALUES('" +
                    animalTextBox.Text + "','" + idadeTextBox.Text + "','" + proprietarioTextBox.Text + "','" +
                    telefoneTextBox.Text + "', '" + observacaoTextBox.Text + "' )";

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
                if (animalTextBox.Text == "" && proprietarioTextBox.Text == "" &&
                    idadeTextBox.Text == "" && telefoneTextBox.Text == "" && observacaoTextBox.Text == "") return;


                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Deleção", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();
                    var id = codigoTextBox.Text;
                    SqlCommand comm = new SqlCommand("DELETE FROM Vacina WHERE Codigo = " + id, _conn);
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
                if (animalTextBox.Text == "" && proprietarioTextBox.Text == "" &&
                   idadeTextBox.Text == "" && telefoneTextBox.Text == "" && observacaoTextBox.Text == "") return;

                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Atualização", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();

                    var stringsql = "UPDATE Vacina SET Animal='" + animalTextBox.Text + "',Idade='" +
                                    idadeTextBox.Text + "',Proprietario='" + proprietarioTextBox.Text + "',Telefone='" +
                                    telefoneTextBox.Text + "',Observacao='" + observacaoTextBox.Text + "' WHERE Codigo = " + codigoTextBox.Text;

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
            animalTextBox.Clear();
            proprietarioTextBox.Clear();
            telefoneTextBox.Clear();
            idadeTextBox.Clear();
            observacaoTextBox.Clear();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            codigoTextBox.Clear();
            animalTextBox.Clear();
            proprietarioTextBox.Clear();
            telefoneTextBox.Clear();
            idadeTextBox.Clear();
            observacaoTextBox.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
