using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// this class consist the main of the program
/// </summary>
namespace Server
{

    class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>

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
