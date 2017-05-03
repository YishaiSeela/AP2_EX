using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// namespace server
/// </summary>
namespace Server
{
    /// <summary>
    /// this class contain the implementation of the command close
    /// </summary>
    class CloseCommand : ICommand
    {
        /// <summary>
        /// Store for the model property/summary>
        private IModel model;
        /// <summary>
        /// Store for the stream property/summary>

        private NetworkStream stream;
        /// <summary>
        /// The writer </summary>
        private BinaryWriter writer;

        /// <summary>
        /// The Constructor of the class</summary>
        /// <param name="model">The model.</param>

        public CloseCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the specified arguments-close connection
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns> 
        /// close comand string
        /// </returns>

        public string Execute(string[] args, TcpClient client)
        {

            //name of maze
            string name = args[0];
            //game to close
            Game toClose = null;
            //clients of game
            TcpClient player1 = null;
            TcpClient player2 = null;

            //if game is found - close both clients
            if (model.GetGameList().ContainsKey(name))
            {
                toClose = model.GetGameList()[name];

                toClose.SetPlayer(client);

                player1 = toClose.getFirstPleyer();
                player2 = toClose.getSecondPleyer();

                //revome game from list
                model.RemoveGame(name);

                //close player 1
                stream = player1.GetStream();
                writer = new BinaryWriter(stream);
                {
                    writer.Write("close");
                    writer.Flush();
                }

                //close player 2
                stream = player2.GetStream();
                writer = new BinaryWriter(stream);
                {
                    writer.Write("close");
                    writer.Flush();
                }


            }
            else //if maze wasn't found - return error message
            {
                return "game dosn't exist";

            }

            return " ";
        }
    }
}