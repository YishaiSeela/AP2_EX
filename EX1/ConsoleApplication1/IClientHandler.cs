using System;
using System.Collections.Generic;
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
    /// client handler
    /// </summary>

    public interface IClientHandler
    {
        /// <summary>
        /// Handles the client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="control">The control.</param>

        void HandleClient(TcpClient client, Controller control);
    }

}