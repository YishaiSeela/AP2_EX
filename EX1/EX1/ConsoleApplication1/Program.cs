using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            ClientHandler ch = new ClientHandler();
            Server server = new Server(8000, ch);
            server.Start();
            Console.ReadLine();
            server.Stop();  
            
        }
    }
}
