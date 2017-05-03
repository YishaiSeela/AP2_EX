using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// namespace server
/// </summary>
namespace Server
{
    /// <summary>
    /// this class consist the main of the program
    /// </summary>
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
            Server server = new Server(ch);
            server.Start();
            Console.ReadLine();
            server.Stop();

        }
    }
}