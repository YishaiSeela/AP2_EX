using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

/// <summary>
/// namespace server
/// </summary>
namespace Server
{
    /// <summary>
    /// this class contain the main of server
    /// </summary>
    class Server
    {
        /// <summary>
        /// The listener
        /// </summary>
        private TcpListener listener;

        /// <summary>
        /// The client handler
        /// </summary>
        private IClientHandler ch;

        /// <summary>
        /// The controller
        /// </summary>
        private Controller controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="port">The port.</param>
        /// <param name="ch">The client handler.</param>
        public Server(IClientHandler ch)
        {
            this.ch = ch;
            this.controller = new Controller();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings[0]),
                int.Parse(ConfigurationManager.AppSettings[1]));
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for connections...");

            //task for connection with server
            Task task = new Task(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        ch.HandleClient(client, controller);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            task.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>

        public void Stop()
        {
            listener.Stop();
        }
    }

}