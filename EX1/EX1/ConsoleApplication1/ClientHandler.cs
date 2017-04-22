using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ClientHandler : IClientHandler
    {

        public void HandleClient(TcpClient client, Controller controller)
        {
           
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader= new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    while (true)
                    {
                        try {
                            string commandLine = reader.ReadString();
                            Console.WriteLine("Got command: {0}", commandLine);
                            string result = controller.ExecuteCommand(commandLine, client);
                            writer.Write(result);
                            writer.Flush();
                        }
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
