using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace Server
{
    class ShowListCommand : ICommand
    {
        private IModel model;

        /*
        * Constructor
        */
        public ShowListCommand(IModel model)
        {
            this.model = model;
        }


        /*
        * ToJSON - get JSON string of list of games
        */
        public string ToJSON(Dictionary<string,Game> games)
        {
            List<String> gameNames = new List<String>();
            //JObject mazeObj = new JObject();
            foreach (Game game in model.GetGameList().Values)        
            {
                if (!game.HasTwoPlayers())
                {
                    gameNames.Add(game.GetName());
                }
            }

            return JsonConvert.SerializeObject(gameNames);
        }

        /*
        * Execute - show list of available games
        */
        public string Execute(string[] args, TcpClient client)
        {

            //retuen JSON string
            return ToJSON(model.GetGameList());
        }


    }
}
