using System;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        #region Constructors

        /// Parameterless constructor -- needed for Deserialization process using xml
        public NamedPipeData() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="order"> OrderID of <see cref="NamedPipeData"/></param>
        /// <param name="guid"> OrderGuid of <see cref="NamedPipeData"/></param>
        public NamedPipeData(int order, Guid guid, bool rdy = false, string msg=null)
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
    }

    /// <summary>
    /// A class that create a named Pipe between our monitor and main application.
    /// </summary>
    public class NamedPipe
    {
        #region Public Methods
        /// <summary>
        /// The names of our named pipes
        /// </summary>
        public static string PipeNameFromApplication {get;} = "Pharmacy2U_NamedPipe_FromApplication";
        public static string PipeNameToApplication { get; } = "Pharmacy2U_NamedPipe_ToApplication";

        public static NamedPipeServerStream namedPipeServerToApplication { get; set; }
        public static NamedPipeClientStream namedPipeClientFromApplication { get; set; }

        #endregion

        #region Constructor

        public NamedPipe()
        {
            namedPipeServerToApplication = new NamedPipeServerStream(PipeNameToApplication);
            namedPipeClientFromApplication = new NamedPipeClientStream(PipeNameFromApplication);
        }


        #endregion

        //public static string ReceivedFromClient { get; set; }
        //public static string ReceivedFromServer { get; set; }

        //public static void SendByteAndReceiveResponse()
        //{
        //    using (NamedPipeServerStream namedPipeServer = new NamedPipeServerStream("Pharm2U_Pipe"))
        //    {
        //        namedPipeServer.WaitForConnection();
        //        namedPipeServer.WriteByte(1);
        //        int byteFromClient = namedPipeServer.ReadByte();
        //        ReceivedFromClient = "FROM CLIENT: " + byteFromClient.ToString();
        //        Console.WriteLine(ReceivedFromClient);

        //        namedPipeServer.W
        //    }
        //}

        //public static void ReceiveByteAndRespond()
        //{
        //    using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream("Pharm2U_Pipe"))
        //    {
        //        namedPipeClient.Connect();
        //        int byteFromServer = namedPipeClient.ReadByte();
        //        ReceivedFromServer = "FROM SERVER: " + byteFromServer.ToString();
        //        Console.WriteLine(ReceivedFromServer);
        //        namedPipeClient.WriteByte(2);

        //    }
        //}
    }
}
