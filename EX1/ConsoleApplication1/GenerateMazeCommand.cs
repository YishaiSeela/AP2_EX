﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using System.Net;
using System.Net.Sockets;

/// <summary>
/// namespace server
/// </summary>
namespace Server
{
    /// <summary>
    /// this class contain the implementation of the command generete maze
    /// </summary>
    /// <seealso cref="Server.ICommand" />
    class GenerateMazeCommand : ICommand
    {
        /// <summary>
        /// Store for the model property/summary&gt;
        /// </summary>

        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateMazeCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public GenerateMazeCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the specified arguments-generate maze.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="client">The client.</param>
        /// <returns>
        /// json string of maze
        /// </returns>
        public string Execute(string[] args, TcpClient client)
        {
            //name of maze
            string name = args[0];
            //size of maze (rows and columns)
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            //generate maze
            Maze maze = model.GenerateMaze(name, rows, cols);
            //add maze to list
            model.AddMaze(maze);
            //set name of maze
            maze.Name = name;
            //retuen JSON string
            return maze.ToJSON();
        }
    }
}