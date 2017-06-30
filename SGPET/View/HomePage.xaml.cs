using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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

namespace SGPET.View
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {

        string strConexao = "";
        SqlConnection conn = null;
        public HomePage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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
                griddatacontrol.ItemsSource = dt.DefaultView; //ds.Tables[0].DefaultView;



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
    }
}
