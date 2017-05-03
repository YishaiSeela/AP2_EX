using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;


/// <summary>
/// namespac server
/// </summary>
namespace Server
{

    /// <summary>
    /// this interface contein the method Execute
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        string Execute(string[] args, TcpClient client = null);
    }

}