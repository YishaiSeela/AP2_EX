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

namespace Server
{
    class CloseCommand : ICommand
    {
        private IModel model;
        private NetworkStream stream;
        private BinaryWriter writer;

        /*
        * Constructor
        */
        public CloseCommand(IModel model)
        {
            this.model = model;
        }

        /*
        * Execute - close connection
        */
        public string Execute(string[] args, TcpClient client)
        {

            //name of maze
            string name = args[0];

            Game toClose = null;
            TcpClient player1 = null;
            TcpClient player2 = null;

            if (model.GetGameList().ContainsKey(name))
            {
                toClose = model.GetGameList()[name];

                toClose.SetPlayer(client);

                player1 = toClose.getFirstPleyer();
                player2 = toClose.getSecondPleyer();

                //revome game from list
                model.RemoveGame(name);

                //close
                stream = player1.GetStream();
                writer = new BinaryWriter(stream);
                {
                    writer.Write("close");
                    writer.Flush();
                }
                stream = player2.GetStream();
                writer = new BinaryWriter(stream);
                {
                    writer.Write("close");
                    writer.Flush();
                }


            }
            else //if maze wasn't found - throw exception
            {
                return "game dosn't exist";

            }

            return " ";
        }
    }
}