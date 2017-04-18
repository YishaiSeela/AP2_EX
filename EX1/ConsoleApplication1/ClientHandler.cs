using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ClientHandler : IClientHandler
    {

        public void HandleClient(TcpClient client)
        {
            Controller controller = new Controller();
            new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    while (true)
                    {
                        string commandLine = reader.ReadLine();
                        Console.WriteLine("Got command: {0}", commandLine);
                        string result = controller.ExecuteCommand(commandLine, client);
                        writer.Write(result);
                        writer.Flush();
                    }
                }
                client.Close();
            }).Start();
        }
    }
}
