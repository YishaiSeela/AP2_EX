using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using System.Net;
using System.Net.Sockets;

/// <summary>
/// this class contain the implementation of the command generete maze
/// </summary>
namespace Server
{
    class GenerateMazeCommand : ICommand
    {
        /// <summary>
        ///  Store for the model property/summary>
        /// </summary>

        private IModel model;

        /// <summary>
        /// The class constructor/summary>
        public GenerateMazeCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the specified arguments-generate maze.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client)
        {
            //name of maze
            string name = args[0];
            //size of maze (rows and columns)
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            //generate maze
            //Maze maze = model.GenerateMaze(name, rows, cols);
            string json = @"{
                'Name': 'mymaze',
                'Maze':
                '0001010001010101110101010000010111111101000001000111010101110001010001011111110100000000011111111111',
                'Rows': 10,
                'Cols': 10,
                'Start': {
                    'Row': 0,
                    'Col': 4
                },
                'End': {
                    'Row': 0,
                    'Col': 0
                }
            }";
            Maze maze = Maze.FromJSON(json);
            //add maze to list
            model.AddMaze(maze);
            //set name of maze
            maze.Name = name;
            //retuen JSON string
            return maze.ToJSON();
        }
    }
}
