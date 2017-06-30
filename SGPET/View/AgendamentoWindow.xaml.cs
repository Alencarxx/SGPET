using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Windows.Controls;
using DevExpress.Xpf.Core;

namespace SGPET.View
{
    /// <summary>
    /// Interaction logic for AgendamentoWindow.xaml
    /// </summary>
    public partial class AgendamentoWindow : DXWindow
    {
        string strConexao = "";
        SqlConnection conn = null;

       

        public AgendamentoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            strConexao = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
            VincularDados();
        }

        public void VincularDados()
        {
            try
            {
                
                // Create a new CultureInfo for the United Kingdom.
                CultureInfo myCultureInfo = new CultureInfo("pt-br");

                conn = new SqlConnection(strConexao);
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Agendamento", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                
                da.Fill(dt);
                dt.Locale = myCultureInfo;
                macDataGrid.ItemsSource = dt.DefaultView; //ds.Tables[0].DefaultView;
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }

        private void macDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.macDataGrid.SelectedCells.Count > 0)
            {
                this.animalTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Animal"].ToString();
                this.banhoTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Banho"].ToString();
                this.diadasemanaTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Diadasemana"].ToString();
                this.foneTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Fone"].ToString();
                this.observacaoTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Observacao"].ToString();
                this.proprietarioTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Proprietario"].ToString();
                this.saidaDatePicker.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Saida"].ToString();
                this.chegadaDatePicker.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Chegada"].ToString();
                this.totalTextBox.Text = ((DataRowView)macDataGrid.SelectedItem).Row["Total"].ToString();
            }
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                conn = new SqlConnection(strConexao);
                conn.Open();

                if (chegadaDatePicker?.SelectedDate == null && saidaDatePicker?.SelectedDate == null) return;
                var date1 = chegadaDatePicker?.SelectedDate.Value.Date;
                var date2 = saidaDatePicker?.SelectedDate.Value.Date;

                string sql = "INSERT INTO Agendamento (Diadasemana, Animal, Proprietario, Fone, Banho, Chegada, Saida, Observacao, Total) VALUES('" + diadasemanaTextBox.Text + "','" + animalTextBox.Text + "','" + proprietarioTextBox.Text + "','" + foneTextBox.Text + "', '" + banhoTextBox.Text + "',  @value , @value2,'" + observacaoTextBox.Text + "', '" + totalTextBox.Text + "' )";

                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@value", date1);
                comm.Parameters.AddWithValue("@value2", date2);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                VincularDados();
            }
        }

    }
}
