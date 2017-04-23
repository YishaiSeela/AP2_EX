using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;



/// <summary>
/// this class consist the main of Client 
/// </summary>
namespace Client
{
  
    class ClientProgram
    {

        /// <summary>
        /// Main of the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>

        static void Main(string[] args)
        {
            Console.Title = "Client";
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            NetworkStream stream = client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);
            Console.Write("Send a request: ");

            //thread to recieve data from server
            Task task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        // Get response from server
                        string text = reader.ReadString();
                        if (text == "close")
                        {
                            client.Close();
                        }
                        Console.WriteLine(text);
                        Console.Write("Send a request: ");
                    }
                    catch (Exception)
                    {
                        client = new TcpClient();
                        client.Connect(ep);
                        stream = client.GetStream();
                        reader = new BinaryReader(stream);
                        writer = new BinaryWriter(stream);
                    }


                }
            });
            task.Start();

            //thread to send data to server
            while (true)
            {

                // Send data to server
                string request = Console.ReadLine();
                writer.Write(request);
                writer.Flush();
            }
        }

    }

}



