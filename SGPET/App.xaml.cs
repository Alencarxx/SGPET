using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using DevExpress.Xpf.Utils.Themes;
using log4net;
using SGPET.View;

namespace SGPET
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
                //StartLog();
                Log.Info("SGPET starting....");
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
                //AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                GlobalThemeHelper.Instance.ApplicationThemeName = "MetropolisDark";
                //SplashScreen.Show();
                LoadDispatcher(() =>
                {
                    MainWindow = new MainWindow();
                    //MainWindow.Loaded += (sender, args) //=> SplashScreen.Close();
                    MainWindow.Show();
                    Log.Info("SGPET started up.");
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private static void LoadDispatcher(Action action, DispatcherPriority priority = DispatcherPriority.Send)
        {
            Current.Dispatcher.BeginInvoke(priority, action);
        }


    }
}
