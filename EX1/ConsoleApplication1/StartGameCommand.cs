using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// namespace server
/// </summary>
namespace Server
{
    /// <summary>
    /// this class contain the implementation of the command start game
    /// </summary>
    class StartGameCommand : ICommand
    {


        private IModel model;
        /// <summary>
        /// Store for the game property
        /// </summary>
        private Game game;


        /// <summary>
        /// The class constructor<
        /// </summary>

        public StartGameCommand(IModel model)
        {
            this.model = model;
        }
        /// <summary>
        /// Executes the specified arguments-generate maze
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns>
        /// Retuen Maze/returns>

        public string Execute(string[] args, TcpClient client)
        {
            bool twoPlayers = false;
            //name of maze
            string name = args[0];
            //size of maze (rows and columns)
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            //generate maze
            Maze maze = model.GenerateMaze(name, rows, cols);
            //set maze name
            maze.Name = name;
            //add maze to list of games
            game = new Game(maze, client);
            model.AddGame(game);
            while (!twoPlayers)
            {
                if (model.GetGameList().ContainsKey(name))
                {
                    twoPlayers = model.GetGameList()[name].HasTwoPlayers();
                }
                Thread.Sleep(10);

            }

            //retuen JSON string
            return maze.ToJSON();
        }

    }
}