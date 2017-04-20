using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Client
{
    class ClientProgram
    {
        //client socket
        private static Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        /*
         * Main
         */
        static void Main(string[] args)
        {
            Console.Title = "Client";
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");

            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                while (true)
                {
                    // Send data to server
                    Console.Write("Send a request: ");
                    string request = Console.ReadLine();
                    writer.Write(request);
                    writer.Flush();

                    // Get result from server
                    string text = reader.ReadString();
                    Console.WriteLine(text);
                }
           }
          
        }

    }


}
