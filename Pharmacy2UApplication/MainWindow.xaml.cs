
using Pharmacy2U_PopupDatabaseMonitor;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Threads
        public Thread ServerThread;
        public Thread ClientThread;
        #endregion

        #region Pipes
        public NamedPipe myPipe;
        #endregion


        #region Default Constructor

        public MainWindow()
        {
            InitializeComponent();

            // Set the data context for the XAML Bindings in the GUI
            //            DataContext = new WindowViewModel(this);

            // Create our pipe object
            myPipe = new NamedPipe();

            //Create two threads -- one for server end
            ServerThread = new Thread(DoServerStuff);
            ServerThread.Start();

            //And the other for a client thread
            ClientThread = new Thread(DoClientStuff);
            ClientThread.Start();

            Console.WriteLine("Program complete");

        }


        #endregion

        #region ThreadFunctions

        private void DoServerStuff()
        {
            // TODO:  Check if the popup application is already running.

            // Starting our popup application
            Process.Start($"C://CS495/Pharmacy2UApplication//Pharmacy2U_PopupDatabaseMonitor/bin/Debug/Pharmacy2U_PopupDatabaseMonitor.exe");
 //           NamedPipe.SendByteAndReceiveResponse();
        }

        private void DoClientStuff()
        {
            // Read from the pipe
            NamedPipe.ReceiveByteAndRespond();

            // Post response to the reponse field.
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background,
                new Action(() => Response.Text = NamedPipe.ReceivedFromServer));
            
        }

        #endregion

        #region Menu Events

        /// <summary>
        /// Menu command to show the database logging window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseLogging_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the display setting
            IoC.Get<ApplicationViewModel>().ShouldHideDatabaseLogging = !IoC.Get<ApplicationViewModel>().ShouldHideDatabaseLogging;

        }

        /// <summary>
        /// Menu command to show the database logging window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugTools_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the display setting
            IoC.Get<ApplicationViewModel>().ShouldHideDebugTools = !IoC.Get<ApplicationViewModel>().ShouldHideDebugTools;

        }

        #endregion

    }
}
