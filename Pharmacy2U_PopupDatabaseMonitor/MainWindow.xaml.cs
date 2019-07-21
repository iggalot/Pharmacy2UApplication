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
        public ObservableCollection<NamedPipeData> ListOfNamedPipeData{get; set;}
        #endregion

        #region Named Pipe Serialization test methods

        public static NamedPipeClientStream _converterStream;
        public static NamedPipeServerStream _resultStream;
        public static bool _convertProcessCompleted = false;
        public static bool _resultProcessCompleted = false;

        /// <summary>
        /// The original data of our pipe process within the database monitor
        /// </summary>
        public static ObservableCollection<NamedPipeData> DefaultData { get; set; }

        /// <summary>
        /// The converted data of our pipe process as received back in the database monitor
        /// </summary>
        public static ObservableCollection<NamedPipeData> ResultData { get; set; }

        /// <summary>
        /// Creates some basic data for our collection (TESTING PURPOSES ONLY)
        /// </summary>
        private static void GenerateDefaultData()
        {
            DefaultData = new ObservableCollection<NamedPipeData>();
            for (int i = 0; i<10; i++)
            {
                NamedPipeData client = new NamedPipeData();
                client.OrderID = i;
                client.OrderGuid = new Guid();
                DefaultData.Add(client);
            }
        }

        /// <summary>
        /// Process default data and send it to the pipe -- this is the Monitor side of the pipe
        /// </summary>
        /// 
        public static void ConverterPipe(ObservableCollection<NamedPipeData> defaultData)
        {
            _converterStream = new NamedPipeClientStream(NamedPipe.PipeNameToApplication);
            _converterStream.Connect();

            foreach (var data in defaultData)
            {
                //changed client data
                NamedPipeData newData = new NamedPipeData()
                {
                    OrderID = data.OrderID + 1000,
                    OrderGuid = data.OrderGuid
                };

                NamedPipeData messageToSend = newData;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(_converterStream, messageToSend);
            }
            _convertProcessCompleted = true;
        }

        /// <summary>
        /// Create the result from the default data (this is the Application side of the pipe).
        /// </summary>
        public void ResultPipe()
        {
            Console.WriteLine("Waiting for connection on named pipe");
            _resultStream = new NamedPipeServerStream(NamedPipe.PipeNameToApplication);
            _resultStream.WaitForConnection();

            while (_resultProcessCompleted == false)
            {
                if(_convertProcessCompleted)
                {
                    _resultProcessCompleted = true;
                    break;
                }
                IFormatter formatter = new BinaryFormatter();
                NamedPipeData clientReceived = (NamedPipeData)formatter.Deserialize(_resultStream);
                Thread.Sleep(1);
                ResultData.Add(clientReceived);
            }
            _resultStream.Close();
        }
        #endregion

        // TODO: Bind window startup locations in XAML to screen size
        public MainWindow()
        {
            InitializeComponent();

            #region Named pipe serialization test

            ResultData = new ObservableCollection<NamedPipeData>();
            GenerateDefaultData();

            Thread resultPipeThread = new Thread(ResultPipe);
            resultPipeThread.IsBackground = true;
            resultPipeThread.Start();

            Thread converterPipeThread = new Thread(() => ConverterPipe(DefaultData));
            converterPipeThread.IsBackground = true;
            converterPipeThread.Start();
            resultPipeThread.Join();

            if (_converterStream != null)
                _converterStream.Close();

            if (_resultStream != null)
                _resultStream.Close();

            Console.WriteLine("OrderID\tOrderGuid");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(DefaultData[i].OrderID + "\t" +ResultData[i].OrderID + "\t" + DefaultData[i].OrderGuid);
            }
            #endregion

        }

        // After loading, send our message to the pipe
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //// Send a message to our pipe
            //NamedPipe.SendByteAndReceiveResponse();

            //// And await the response
            //Response.Text = NamedPipe.ReceivedFromClient;
        }
    }
}
