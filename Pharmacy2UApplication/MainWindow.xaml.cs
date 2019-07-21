
using Pharmacy2U_PopupDatabaseMonitor;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

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
            DataContext = new WindowViewModel(this);


            //// SERIALIZATION

            //// Create our popup data element
            //NamedPipeData popupData = new NamedPipeData(1, new Guid());

            //// Serialize the object data into a stream.
            //Stream stream = File.Open("PopupData.dat", FileMode.Create);

            //// Set to binary format
            //BinaryFormatter bf = new BinaryFormatter();

            //// Serialize the data and send to the stream
            //bf.Serialize(stream, popupData);

            //// Close the stream
            //stream.Close();

            //// Clear the item
            //popupData = null;

            //// DESERIALIZATION

            //// Serialize the object data into a stream.
            //stream = File.Open("PopupData.dat", FileMode.Open);

            //bf = new BinaryFormatter();

            //popupData = (NamedPipeData)bf.Deserialize(stream);
            //stream.Close();
            //Console.WriteLine(popupData.ToString());


            //// Rewrite the value as a test
            //popupData.OrderID = 2;

            //// SEtup the XML serializer
            //XmlSerializer serializer = new XmlSerializer(typeof(NamedPipeData));

            //using(TextWriter tw = new StreamWriter(@"C:\CS495\Pharmacy2UApplication\Pharmacy2UApplication\bin\Debug\PopData.xml"))
            //{
            //    serializer.Serialize(tw, popupData);

            //}

            //popupData = null;

            //XmlSerializer deserializer = new XmlSerializer(typeof(NamedPipeData));
            //TextReader reader = new StreamReader(@"C:\CS495\Pharmacy2UApplication\Pharmacy2UApplication\bin\Debug\PopData.xml");
            //object obj = deserializer.Deserialize(reader);
            //popupData = (NamedPipeData)obj;

            //Console.WriteLine(popupData.ToString());

            //// Create a list of objects
            //ObservableCollection<NamedPipeData> thePopupData = new ObservableCollection<NamedPipeData>
            //{
            //    new NamedPipeData(3, new Guid()),
            //    new NamedPipeData(4, new Guid()),
            //    new NamedPipeData(5, new Guid()),
            //};

            //using(Stream fs = new FileStream(@"C:\CS495\Pharmacy2UApplication\Pharmacy2UApplication\bin\Debug\PopDataList.xml",
            //    FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    XmlSerializer serializer2 = new XmlSerializer(typeof(ObservableCollection<NamedPipeData>));
            //    serializer2.Serialize(fs, thePopupData);
            //}

            //thePopupData = null;

            //XmlSerializer serializer3 = new XmlSerializer(typeof(ObservableCollection<NamedPipeData>));

            //using(FileStream fs2 = File.OpenRead(@"C:\CS495\Pharmacy2UApplication\Pharmacy2UApplication\bin\Debug\PopDataList.xml"))
            //{
            //    thePopupData = (ObservableCollection<NamedPipeData>)serializer3.Deserialize(fs2);
            //}

            //foreach(NamedPipeData n in thePopupData)
            //{
            //    Console.WriteLine(n.ToString());
            //}

            //// Create our pipe object
            //myPipe = new NamedPipe();

            ////Create two threads -- one for server end
            //ServerThread = new Thread(DoServerStuff);

            //// Make the thread a background thread so it exit when the app exits
            //ServerThread.IsBackground = true;

            //// Start the server thread.
            //ServerThread.Start();

            ////And the other for a client thread
            //ClientThread = new Thread(DoClientStuff);

            //// Make the thread a background thread so it exits when the app exits
            //ClientThread.IsBackground = true;

            //// Start the client thread
            //ClientThread.Start();

            Console.WriteLine("Program complete");
        }

        #endregion

        #region ThreadFunctions

        //private void DoServerStuff()
        //{
        //    // TODO:  Check if the popup application is already running.

        //    // Starting our popup application
        //    Process.Start($"C://CS495/Pharmacy2UApplication//Pharmacy2U_PopupDatabaseMonitor/bin/Debug/Pharmacy2U_PopupDatabaseMonitor.exe");
        //}

        //private void DoClientStuff()
        //{
        //    // Read from the pipe
        //    NamedPipe.ReceiveByteAndRespond();

        //    // Post response to the reponse field.  Must use the dispatcher since the UI element is on the main thread and we
        //    // are currently on the pipe client's thread.
        //    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background,
        //        new Action(() => Response.Text = NamedPipe.ReceivedFromServer));
            
        //}

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
