using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using log4net;

namespace SGPET.View
{
    /// <summary>
    /// Interaction logic for Clientes.xaml
    /// </summary>
    public partial class ClientesPage : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string strConexao = "";
        SqlConnection conn = null;

        public ClientesPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                strConexao = ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString;
                RebindData();
                SetTimer();
            }
            catch (SqlException ex)
            {
                Log.Error("Error UserControl_Loaded: " + ex.Message);
            }
        }

        //Refreshes grid data on timer tick
        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RebindData();
        }

        //Get data and bind to the grid
        private void RebindData()
        {
            VincularDados();
        }

        //Set and start the timer
        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void VincularDados()
        {
            try
            {
                // Create a new CultureInfo for the United Kingdom.
                CultureInfo myCultureInfo = new CultureInfo("pt-br");

                conn = new SqlConnection(strConexao);
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM Cliente", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comm);

                da.Fill(dt);
                dt.Locale = myCultureInfo;
                griddatacontrol.ItemsSource = dt.DefaultView; //ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                Log.Error("Erro VincularDados: " + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
