using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// /// this class consist the command of join game
/// </summary>


namespace Server
{
    class JoinGameCommand : ICommand
    {
        /// <summary>
        /// Store for the model property/summary>

        /// </summary>

        private IModel model;
        /// <summary>
        /// Store The correct game
        /// </summary>

        private Game correctGame;

        /// <summary>
        /// The class constructor/summary>
        /// </summary>
        /// <param name="model">The model.</param>

        public JoinGameCommand(IModel model)
        {
            this.model = model;
        }

        /*
        * Execute - generate maze
        */
        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns>getMaze/returns>
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
