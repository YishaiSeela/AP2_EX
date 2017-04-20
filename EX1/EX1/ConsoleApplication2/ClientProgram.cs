using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    class ClientProgram
    {
        private static Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main()
        {
            Console.Title = "Client";
            ConnectToServer();
            RequestLoop();
            Exit();
        }

        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(IPAddress.Parse("127.0.0.1"), 8000);
                }
                catch (SocketException)
                {
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Connected");
        }

        private static void RequestLoop()
        {
            //Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");

            while (true)
            {
                Console.Write("Send a request: ");
                //string request = Console.ReadLine();
                byte[] request = Encoding.ASCII.GetBytes(Console.ReadLine());
                ClientSocket.Send(request, 0, request.Length, SocketFlags.None);

                if (request.ToString() == "exit")
                {
                    Exit();
                }

                var buffer = new byte[16384];
                int received = ClientSocket.Receive(buffer, SocketFlags.None);
                if (received == 0) return;
                var data = new byte[received];
                Array.Copy(buffer, data, received);
                string text = Encoding.ASCII.GetString(data);
                Console.WriteLine(text);
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        private static void Exit()
        {
            var exit = Encoding.ASCII.GetBytes("exit");
            ClientSocket.Send(exit, 0, exit.Length, SocketFlags.None); // Tell the server we are exiting
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }
    }
}