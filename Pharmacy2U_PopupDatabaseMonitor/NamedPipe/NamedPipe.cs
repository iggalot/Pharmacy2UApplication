using System;
using System.IO.Pipes;

namespace Pharmacy2U_PopupDatabaseMonitor
{
    public class NamedPipe
    {
        public static string ReceivedFromClient { get; set; }
        public static string ReceivedFromServer { get; set; }

        public static void SendByteAndReceiveResponse()
        {
            using (NamedPipeServerStream namedPipeServer = new NamedPipeServerStream("Pharm2U_Pipe"))
            {
                namedPipeServer.WaitForConnection();
                namedPipeServer.WriteByte(1);
                int byteFromClient = namedPipeServer.ReadByte();
                ReceivedFromClient = "FROM CLIENT: " + byteFromClient.ToString();
                Console.WriteLine(ReceivedFromClient);
                
            }
        }

        public static void ReceiveByteAndRespond()
        {
            using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream("Pharm2U_Pipe"))
            {
                namedPipeClient.Connect();
                int byteFromServer = namedPipeClient.ReadByte();
                ReceivedFromServer = "FROM SERVER: " + byteFromServer.ToString();
                Console.WriteLine(ReceivedFromServer);
                namedPipeClient.WriteByte(2);
                
            }
        }
    }
}
