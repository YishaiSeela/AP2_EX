using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class JoinGameCommand : ICommand
    {
        private IModel model;
        private Game correctGame;

        /*
        * constructor
        */
        public JoinGameCommand(IModel model)
        {
            this.model = model;
        }

        /*
        * Execute - generate maze
        */
        public string Execute(string[] args, TcpClient client)
        {
            //initialize correct game
            correctGame = null;
            //name of maze
            string name = args[0];
            //find the maze to solve

            if (model.GetGameList().ContainsKey(name))
            {
                correctGame = model.GetGameList()[name];

                correctGame.SetPlayer(client);

                Thread.Sleep(10);
                //revome game from list
                model.RemoveGame(correctGame.GetName());
                //retuen JSON string
                return correctGame.GetMaze().ToJSON();
            }
            else //if maze wasn't found - throw exception
            {
                return "game dosn't exist";

            }

        }
    }
}
