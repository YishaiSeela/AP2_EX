using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
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
            foreach (Game game in model.GetGameList())
            {
                //if a maze with the same name was found - save it
                if (game.GetName() == name)
                {
                    correctGame = game;
                }
            }
            //if maze wasn't found - throw exception
            if (correctGame == null)
            {
                return "game dosn't exist";
            }
            else
            {
                correctGame.SetPlayer(client);
                //revome game from list
                model.RemoveGame(correctGame);  
                //retuen JSON string
                return correctGame.GetMaze().ToJSON();
            }
        }
    }
}
