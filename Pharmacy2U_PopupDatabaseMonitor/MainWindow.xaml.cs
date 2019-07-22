using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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

namespace Pharmacy2U_PopupDatabaseMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public Properties

        /// <summary>
        /// A collection of NamedPipeData objects.  Used for storing the OrderID and Order Guid of a new record
        /// within the monitor prior to sending to the application via the acknowledge click.
        /// </summary>
                /// <summary>
        /// The original data of our pipe process within the database monitor
        /// </summary>
        public static ObservableCollection<NamedPipeData> NewOrderData { get; set; }
        #endregion

        #region Named Pipe Serialization test methods


        /// <summary>
        /// Creates some basic data for our collection (TESTING PURPOSES ONLY)
        /// </summary>
        private static ObservableCollection<NamedPipeData> GenerateDefaultData()
        {
            ObservableCollection<NamedPipeData> temp = new ObservableCollection<NamedPipeData>();
            for (int i = 0; i<3; i++)
            {
                NamedPipeData client = new NamedPipeData();
                client.OrderID = i;
                client.OrderGuid = new Guid();
                temp.Add(client);
            }

            return temp;
        }


        #endregion

        // TODO: Bind window startup locations in XAML to screen size
        public MainWindow()
        {
            InitializeComponent();

            #region Named pipe serialization test

            // Create our server stream named pipe
            NamedPipe.ServerStream = new NamedPipeServerStream(NamedPipe.PipeNameFromMonitorToApplication, PipeDirection.InOut, 1);


            // Generate default data
            NewOrderData = GenerateDefaultData();

            Thread FromMonitorPipeThread = new Thread(SendData);
            FromMonitorPipeThread.IsBackground = true;
            FromMonitorPipeThread.Start();

            Console.WriteLine("DB monitor pipe thread started...");

            FromMonitorPipeThread.Join();

            //if (NamedPipe._fromMonitorToApplicationPipeStream != null)
            //    NamedPipe._fromMonitorToApplicationPipeStream.Close();

            Console.WriteLine("OrderID\tOrderGuid");
            for (int i = 0; i < NewOrderData.Count; i++)
            {
                Console.WriteLine("DB Monitor: " + NewOrderData[i].OrderID + "\t" + NewOrderData[i].OrderGuid);
            }
            #endregion

        }

        private void SendData()
        {
            Console.WriteLine("Receiving data from monitor...");
            // Receives the new order data from the monitor
            NamedPipe.SendToApplication(NewOrderData);
            Console.WriteLine("Data received....returning to main application...");
        }

        // After loading, send our message to the pipe
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
