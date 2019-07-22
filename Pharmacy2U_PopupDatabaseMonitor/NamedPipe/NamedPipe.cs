using System;
using System.Collections.ObjectModel;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Pharmacy2U_PopupDatabaseMonitor
{
    /// <summary>
    /// A serializeable class that reflects information that the database monitor detects from 
    /// monitoring the SQL database.
    /// </summary>
    [Serializable]   // tag for allowing a class to be serialized
    public class NamedPipeData : ISerializable
    {
        #region Public Properties

        /// <summary>
        /// The order number of the record to be sent from the monitor to the application
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// The order guid of the record
        /// </summary>
        public Guid OrderGuid { get; set; }

        #endregion


        #region Public Methods 

        /// <summary>
        /// ToString override function
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("OrderID: {0} and OrderGuid: {1}", OrderID, OrderGuid);
        }

        #endregion

        #region Serialize Interface Implementation

        /// <summary>
        /// Serialization function.
        /// Serializes the data of the NamedPipeData.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderID", OrderID);
            info.AddValue("OrderGuid", OrderGuid);
        }
        #endregion

        #region Constructors

        /// Parameterless constructor -- needed for Deserialization process using xml
        public NamedPipeData() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="order"> OrderID of <see cref="NamedPipeData"/></param>
        /// <param name="guid"> OrderGuid of <see cref="NamedPipeData"/></param>
        public NamedPipeData(int order, Guid guid, bool rdy = false, string msg = null)
        {
            OrderID = order;
            OrderGuid = guid;
        }

        /// <summary>
        /// Deserialization function that retrieves the data from the serialized string.
        /// </summary>
        /// <param name="info">The serialized string</param>
        /// <param name="context">The type of serialization</param>
        public NamedPipeData(SerializationInfo info, StreamingContext context)
        {
            OrderID = (int)info.GetValue("OrderID", typeof(int));
            OrderGuid = (Guid)info.GetValue("OrderGuid", typeof(Guid));
        }

        #endregion

    }

    /// <summary>
    /// A class that create a named Pipe between our monitor and main application.
    /// </summary>
    public class NamedPipe
    {
        #region Public Members
        ObservableCollection<NamedPipeData> _receivedPipeData { get; set; }

        /// <summary>
        /// Named pipe server stream for sending data from the database monitor to the main application
        /// </summary>
        public static NamedPipeServerStream ServerStream { get; set; }

        /// <summary>
        /// Named pipe client stream for receiving data in the main application from the database monitor
        /// </summary>
        public static NamedPipeClientStream ClientStream { get; set; }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// The name of our named pipe
        /// </summary>
        public static string PipeNameFromMonitorToApplication { get; } = "Pharmacy2U_NamedPipe_FromMonitorToApplication";

        #endregion

        #region Constructor

        public NamedPipe()
        {
            //// Create our server pipe stream
            //if(ServerStream == null)
            //    ServerStream = new NamedPipeServerStream(NamedPipe.PipeNameFromMonitorToApplication, PipeDirection.Out, 1);

            //// Create our client pipe stream
            //if(ClientStream == null)
            //    ClientStream = new NamedPipeClientStream(NamedPipe.PipeNameFromMonitorToApplication);

        }

        #endregion

        #region Public Methods
        public static ObservableCollection<NamedPipeData> ReceiveFromMonitor()
        {
            bool endOfData = false;
            ObservableCollection<NamedPipeData> temp = new ObservableCollection<NamedPipeData>();

            ClientStream.Connect();

            // Read everything in the pipe
            int recordCount = 0;
            while(!endOfData)
            {
                IFormatter formatter = new BinaryFormatter();
                NamedPipeData clientReceived = (NamedPipeData)formatter.Deserialize(ClientStream);
                Thread.Sleep(1);

                // If this is the dummy record at the end of the transmission
                if(clientReceived.OrderID == -1)
                {
                    Console.WriteLine($"End of records transmission. {recordCount} records received.");
                    endOfData = true;
                    continue;
                }

                // Otherwise add it to our temporary collection
                temp.Add(clientReceived);
                recordCount++;
            }

            // Return the collection to the application
            return temp;
        }

        /// <summary>
        /// Process default data and send it to the pipe -- this is the Monitor side of the pipe
        /// </summary>
        /// 
        public static void SendToApplication(ObservableCollection<NamedPipeData> defaultData)
        {
            // Wait for the application to connecte
            //TODO:  tests for pipe connection needed here....

            Console.WriteLine("Waiting for connection on main application...");
            ServerStream.WaitForConnection();

            // Send each record through the pipe to the application
            int count = 0;
            foreach (var data in defaultData)
            {
                NamedPipeData messageToSend = data;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ServerStream, messageToSend);
                count++;
            }

            // Now add a dummy record on the end of the transmission
            // with an order number of -1 to signify the end of the list.
            NamedPipeData temp = new NamedPipeData(-1, new Guid());

            IFormatter formatter2 = new BinaryFormatter();
            formatter2.Serialize(ServerStream, temp);
        }

        #endregion
    }
}
