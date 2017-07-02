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
    /// Interaction logic for AgendamentoWindow.xaml
    /// </summary>
    public partial class AgendamentoWindow : DXWindow
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string _strConexao = "";
        SqlConnection _conn;

        public AgendamentoWindow()
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
                SqlCommand comm = new SqlCommand("SELECT * FROM Agendamento", _conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);

                da.Fill(dt);
                macDataGrid.ItemsSource = dt.DefaultView;
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

        private void macDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (macDataGrid.SelectedCells.Count > 0)
            {
                idTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Id"].ToString();
                animalTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Animal"].ToString();
                banhoTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Banho"].ToString();
                diadasemanaTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Diadasemana"].ToString();
                foneTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Fone"].ToString();
                observacaoTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Observacao"].ToString();
                proprietarioTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Proprietario"].ToString();
                saidaDatePicker.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Saida"].ToString();
                chegadaDatePicker.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Chegada"].ToString();
                totalTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Total"].ToString();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (diadasemanaTextBox.Text == "" && animalTextBox.Text == "" && proprietarioTextBox.Text == "" &&
                    foneTextBox.Text == "" && banhoTextBox.Text == "" && observacaoTextBox.Text == "" && totalTextBox.Text == "") return;

                _conn = new SqlConnection(_strConexao);
                _conn.Open();

                if (chegadaDatePicker?.SelectedDate != null)
                {
                    var date1 = chegadaDatePicker?.SelectedDate.Value.Date;
                    if (saidaDatePicker?.SelectedDate != null)
                    {
                        var date2 = saidaDatePicker?.SelectedDate.Value.Date;

                        string sql =
                            "INSERT INTO Agendamento (Diadasemana, Animal, Proprietario, Fone, Banho, Chegada, Saida, Observacao, Total) VALUES('" +
                            diadasemanaTextBox.Text + "','" + animalTextBox.Text + "','" + proprietarioTextBox.Text + "','" +
                            foneTextBox.Text + "', '" + banhoTextBox.Text + "',  @value , @value2,'" +
                            observacaoTextBox.Text + "', '" + totalTextBox.Text + "' )";

                        SqlCommand comm = new SqlCommand(sql, _conn);
                        comm.Parameters.AddWithValue("@value", date1);
                        comm.Parameters.AddWithValue("@value2", date2);
                        comm.ExecuteNonQuery();
                    }
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

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (diadasemanaTextBox.Text == "" && animalTextBox.Text == "" && proprietarioTextBox.Text == "" &&
                   foneTextBox.Text == "" && banhoTextBox.Text == "" && observacaoTextBox.Text == "" && totalTextBox.Text == "") return;


                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Deleção", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();
                    var id = idTextBox.Text;
                    SqlCommand comm = new SqlCommand("DELETE FROM Agendamento WHERE Id = " + id, _conn);
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
                if (diadasemanaTextBox.Text == "" && animalTextBox.Text == "" && proprietarioTextBox.Text == "" &&
                   foneTextBox.Text == "" && banhoTextBox.Text == "" && observacaoTextBox.Text == "" && totalTextBox.Text == "") return;

                MessageBoxResult messageBoxResult = MessageBox.Show("Você tem certeza?", "Confirmar Atualização", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    _conn = new SqlConnection(_strConexao);
                    _conn.Open();

                    if (chegadaDatePicker?.SelectedDate != null || saidaDatePicker?.SelectedDate != null)
                    {
                        var date1 = chegadaDatePicker?.SelectedDate.Value.Date;
                        var date2 = saidaDatePicker?.SelectedDate.Value.Date;

                        var stringsql = "UPDATE Agendamento SET Diadasemana='" + diadasemanaTextBox.Text + "',Animal='" +
                                        animalTextBox.Text + "',Proprietario='" + proprietarioTextBox.Text + "',Fone='" +
                                        foneTextBox.Text + "',Banho='" + banhoTextBox.Text + "',Chegada = @Date1" +
                                        ",Saida = @Date2 ,Observacao='" + observacaoTextBox.Text + "',Total='" + totalTextBox.Text +
                                        "' WHERE Id = " + idTextBox.Text;

                        //string sql = "update statuses set stat = @stat, tester = @tester" + ", timestamp_m = getdate()" + " where id IN (" + IDs + ") and timestamp_m < @pageLoadTime";

                        SqlCommand comm = new SqlCommand(stringsql, _conn);
                        //comm.Parameters.Add("@pageLoadTime", System.Data.SqlDbType.DateTime).Value = pageLoadTime;
                        comm.Parameters.AddWithValue("@Date1", date1);
                        comm.Parameters.AddWithValue("@Date2", date2);
                        comm.ExecuteNonQuery();
                    }
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

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            idTextBox.Clear();
            diadasemanaTextBox.Text = "";
            animalTextBox.Clear();
            proprietarioTextBox.Clear();
            foneTextBox.Clear();
            banhoTextBox.Clear();
            chegadaDatePicker.Text = "";
            saidaDatePicker.Text = "";
            observacaoTextBox.Clear();
            totalTextBox.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
