using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    class PlayCommand : ICommand
    {
        private IModel model;

        /*
        * Constructor
        */
        public PlayCommand(IModel model)
        {
            this.model = model;
        }

        /*
        * ToJSON - get JSON string of list of games
        */
        public string ToJSON(string name, string direction)
        {
            JObject mazeObj = new JObject();
            mazeObj["Name"] = name;
            mazeObj["Direction"] = direction;

            return mazeObj.ToString();
        }

        /*
        * Execute - play a move
        */
        public string Execute(string[] args, TcpClient client)
        {
            Game currentGame = null;
            TcpClient otherPlayer = null;
            foreach (Game game in model.GetGameList().Values)
            {
                Console.WriteLine(game.GetName()+game.HasTwoPlayers());

                if ((game.getFirstPleyer() == client) || (game.getSecondPleyer() == client))
                {
                    currentGame = game;
                    otherPlayer = currentGame.getOtherPleyer(client);
                }
            }
            /*
            using (NetworkStream stream = otherPlayer.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                string result = ToJSON(currentGame.GetName(), args[0]);
                writer.Write(result);
                writer.Flush();
            }*/
            
            return ToJSON(currentGame.GetName(), args[0]); // ToJSON(model.GetGameList());
        }
    }
}