using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// this class contain the main of server
/// </summary>
namespace Server
{

    class Server
        {
        /// <summary>
        /// The port
        /// </summary>

        private int port;
        /// <summary>
        /// The listener
        /// </summary>

        private TcpListener listener;
        /// <summary>
        /// The ch
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
        /// <param name="ch">The ch.</param>

        public Server(int port, IClientHandler ch)
            {
                this.port = port;
                this.ch = ch;
                this.controller = new Controller();
            }

        /// <summary>
        /// Starts this instance.
        /// </summary>

        public void Start()
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                listener = new TcpListener(ep);

                listener.Start();
                Console.WriteLine("Waiting for connections...");

                Task task = new Task(() => {
                    while (true)
                    {
                        try
                        {
                            TcpClient client = listener.AcceptTcpClient();
                            Console.WriteLine("Got new connection");
                            ch.HandleClient(client,controller);
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