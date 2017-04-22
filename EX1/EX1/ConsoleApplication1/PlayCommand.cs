﻿using Newtonsoft.Json;
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
        private NetworkStream stream;
        private BinaryWriter writer;

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