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


/// /// <summary>
/// this class consist the command of play 
/// </summary>

namespace Server 
{

    class PlayCommand : ICommand
    {
        /// <summary>
        /// Store The model prpoerty</summary>

        private IModel model;
        /// <summary>
        /// Store The stream prpoerty</summary>
        
        private NetworkStream stream;
        /// <summary>
        /// The writer </summary>

        private BinaryWriter writer;
        /// <summary>
        /// The valid directions/// </summary>

        private List<string> validDirections = new List<string>();

        /// <summary>
        /// The constructor of the class
        /// <summary>
        public PlayCommand(IModel model)
        {
            this.model = model;
            validDirections.Add("Right");
            validDirections.Add("right");
            validDirections.Add("Left");
            validDirections.Add("left");
            validDirections.Add("Up");
            validDirections.Add("up");
            validDirections.Add("Down");
            validDirections.Add("down");

        }


  
        /// <summary>
        /// get JSON string of list of games
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="direction">The direction.</param>
        /// <returns><mazeJob</returns>

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
        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>

        public string Execute(string[] args, TcpClient client)
        {
            Game currentGame = null;
            TcpClient otherPlayer = null;
            if (!validDirections.Contains(args[0]))
            {
                return "Invalid Direction";
            }
            else
            {
                foreach (Game game in model.GetGameList().Values)
                {
                    if ((game.getFirstPleyer() == client) || (game.getSecondPleyer() == client))
                    {
                        currentGame = game;
                        otherPlayer = currentGame.getOtherPleyer(client);
                    }
                }

                stream = otherPlayer.GetStream();
                writer = new BinaryWriter(stream);
                {
                    string result = ToJSON(currentGame.GetName(), args[0]);
                    writer.Write(result);
                    writer.Flush();
                }

                return " ";
            }
        }
    }
}