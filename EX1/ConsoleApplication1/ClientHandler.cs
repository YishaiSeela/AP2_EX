using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// namespace server
/// </summary>
namespace Server
{
    /// <summary>
    /// this clas implement the IClientHandler
    /// </summary>
    class ClientHandler : IClientHandler
    {

        /// <summary>
        /// Handles the client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="controller">The controller.</param>
        public void HandleClient(TcpClient client, Controller controller)
        {
            //new task to handle client
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    while (true)
                    {
                        try
                        {
                            //execute given command
                            string commandLine = reader.ReadString();
                            Console.WriteLine("Got command: {0}", commandLine);
                            string result = controller.ExecuteCommand(commandLine, client);
                            writer.Write(result);
                            writer.Flush();
                            //close connection if it's not a multiplayer command
                            if (!controller.isMultiCommand())
                            {
                                break;
                            }
                        }
                        //close connection if an exception occurred
                        catch (Exception)
                        {
                            break;
                        }
                    }

                }
                client.Close();
            }).Start();
        }
    }
}
