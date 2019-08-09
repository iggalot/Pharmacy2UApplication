using Pharmacy2UApplication.Core;
using System;
using System.Reflection;
using System.Windows;

namespace Pharmacy2U_PopupDatabaseMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            using(SingleProgramInstance spi = new SingleProgramInstance("x5k6yz"))
            {
                if (spi.IsSingleInstance)
                {
                    // Set the startup URI as normal
                    StartupUri = new Uri("/Pharmacy2U_PopupDatabaseMonitor;component/MainWindow.xaml", UriKind.Relative);
                } else
                {
                    MessageBox.Show("Duplicate application " + Assembly.GetExecutingAssembly().GetName().Name + "shown -- raising the other one instead of launching a new one");
                    spi.RaiseOtherProcess();
                }
            }

        }
    }
}
