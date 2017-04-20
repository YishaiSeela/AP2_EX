using Newtonsoft.Json;
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
        public string ToJSON(string move)
        {
            List<String> gameNames = new List<String>();
            //JObject mazeObj = new JObject();
            foreach (KeyValuePair<string, Game> game in model.GetGameList())

            {
                gameNames.Add(game.ToString());
            }

            return JsonConvert.SerializeObject(gameNames);
            //return mazeObj.ToString();
        }

        /*
        * Execute - play a move
        */
        public string Execute(string[] args, TcpClient client)
        {
            Game currentGame;
            TcpClient otherPlayer;
            foreach (Game game in model.GetGameList().Values)
            {
                if (game.getFirstPleyer() == client)
                {
                    currentGame = game;
                    otherPlayer = currentGame.getSecondPleyer(client);
                }
            }

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {

                string result = ToJSON(args[1]);
                writer.Write(result);
                writer.Flush();

            }
            return "nothing"; // ToJSON(model.GetGameList());
        }
    }
}