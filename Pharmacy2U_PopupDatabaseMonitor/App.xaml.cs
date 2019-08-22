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
        protected override void OnStartup(StartupEventArgs e)
        {
                //// Set the startup URI as normal
                //StartupUri = new Uri("/Pharmacy2U_PopupDatabaseMonitor;component/MainWindow.xaml", UriKind.Relative);

                // let the base application do what it needs for startup
                base.OnStartup(e);

                // Setup IoC right away
                IoC.Setup();

                // Bind to a single instance of Order view model
                IoC.Kernel.Bind<DatabaseQueryViewModel>().ToConstant(new DatabaseQueryViewModel());

                // Show the main window
                Current.MainWindow = new MainWindow();
                Current.MainWindow.Show();              
        }
    }
}
