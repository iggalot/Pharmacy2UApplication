using Pharmacy2UApplication.Core;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace Pharmacy2UApplication
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
                using (SingleProgramInstance spi = new SingleProgramInstance("abcdefg"))
                {
                    if (spi.IsSingleInstance)
                    {
                        //// Set the startup URI as normal
                        //StartupUri = new Uri("/Pharmacy2U_PopupDatabaseMonitor;component/MainWindow.xaml", UriKind.Relative);

                        // let the base application do what it needs for startup
                        base.OnStartup(e);

                        // Setup IoC right away
                        IoC.Setup();

                        // Show the main window
                        Current.MainWindow = new MainWindow();
                        Current.MainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Duplicate application " + Assembly.GetExecutingAssembly().GetName().Name + "shown -- raising the other one instead of launching a new one");
                    
                        // Raise the other instance
                        spi.RaiseOtherProcess();

                        //// Shutdown the current application since its not needed.
                        System.Windows.Application.Current.Shutdown();

                        // Release the mutex of this instance and dispose of the item...
                        spi.Dispose();

                    }
            }


            //// let the base application do what it needs
            //base.OnStartup(e);

            //// Setup IoC right away
            //IoC.Setup();

            //// Show the main window
            //Current.MainWindow = new MainWindow();
            //Current.MainWindow.Show();
        }
    }
}
