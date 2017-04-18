using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApplication1
{
    class GenerateMazeCommand : ICommand
    {
        private IModel model;

        /*
        * constructor
        */
        public GenerateMazeCommand(IModel model)
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
            //set name of maze
            maze.Name = name;
            //retuen JSON string
            return maze.ToJSON();
        }
    }
}
