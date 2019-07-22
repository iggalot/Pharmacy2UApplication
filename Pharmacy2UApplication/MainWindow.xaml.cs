using Pharmacy2UApplication.Core;
using System;
using System.Collections.ObjectModel;
using System.IO.Pipes;
using System.Threading;
using System.Windows;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public Members

        ObservableCollection<NamedPipeData> NewOrderData { get; set; }

        #endregion

        public ApplicationViewModel ApplicationViewModel => new ApplicationViewModel();


        #region Default Constructor

        public MainWindow()
        {
            InitializeComponent();

            // Set the data context for the XAML Bindings in the GUI
            DataContext = new WindowViewModel(this);

            //// Create a named pipe
            //NewOrderData = new ObservableCollection<NamedPipeData>();

            //// Create the client client pipe stream for reading data received from the database monitor
            //NamedPipe.ClientStream = new NamedPipeClientStream(".", NamedPipe.PipeNameFromMonitorToApplication, PipeDirection.InOut);

            //// Create a thread to listen for records from the database monitor
            //Thread FromMonitorPipeThread = new Thread(ReceiveData);
            //FromMonitorPipeThread.IsBackground = true;
            //FromMonitorPipeThread.Start();

            //FromMonitorPipeThread.Join();

            //Console.WriteLine("OrderID\tOrderGuid");
            //for (int i = 0; i < NewOrderData.Count; i++)
            //{
            //    Console.WriteLine("Application: " + NewOrderData[i].OrderID + "\t" + NewOrderData[i].OrderGuid);
            //}
        }

        private void ReceiveData()
        {
            Console.WriteLine("Receiving data from monitor...");
            // Receives the new order data from the monitor
            NewOrderData = NamedPipe.ReceiveFromMonitor();
            Console.WriteLine("Data received....returning to main application...");
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
