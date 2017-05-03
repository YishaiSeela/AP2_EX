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

/// <summary>
/// namespace server
/// </summary>
namespace Server
{
    /// <summary>
    ///  this class contain the implementation of the command show list
    /// </summary>
    /// <seealso cref="Server.ICommand" />

    class ShowListCommand : ICommand
    {
        /// <summary>
        /// The model
        /// </summary>

        private IModel model;

        /*
        * constructor
        */
        /// <summary>
        /// The Constructor of the class</summary>

        public ShowListCommand(IModel model)
        {
            this.model = model;
        }


        /// <summary>
        ///  get JSON string of list of games
        /// </summary>
        /// <param name="games">The games.</param>
        /// <returns> json string of list of games </returns>
        public string ToJSON(Dictionary<string, Game> games)
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


        /// <summary>
        /// Executes the specified arguments,show list of available games.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>

        public string Execute(string[] args, TcpClient client)
        {

            //retuen JSON string
            return ToJSON(model.GetGameList());
        }


    }
}