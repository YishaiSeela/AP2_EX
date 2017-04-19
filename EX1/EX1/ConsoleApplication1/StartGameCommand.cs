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
    class StartGameCommand : ICommand
    {
        private IModel model;
        private Game game;

        /*
        * constructor
        */
        public StartGameCommand(IModel model)
        {
            this.model = model;
        }

        /*
        * Execute - generate maze
        */
        public string Execute(string[] args, TcpClient client)
        {
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

            while (!game.HasTwoPlayers()) {
                Thread.Sleep(10);
            }
            //retuen JSON string
            return maze.ToJSON();
        }

    }
}
