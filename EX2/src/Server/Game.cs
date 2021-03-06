﻿using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 
/// </summary>
namespace Server
{
    /// <summary>
    /// 
    /// </summary>

    public class Game
    {
        /// <summary>
        /// The maze
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for maze
        private Maze maze;
        /// <summary>
        /// The name
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for name
        private string name;
        /// <summary>
        /// The player1
        /// </summary>
     
        private TcpClient player1;
        /// <summary>
        /// The player2
        /// </summary>

        private TcpClient player2;
        /// <summary>
        /// The has two players
        /// </summary>

        private Boolean hasTwoPlayers;

        /*
         * constructor
         */
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="maze">The maze.</param>
        /// <param name="player">The player.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        public Game(Maze maze, TcpClient player)
        {

            this.maze = maze;
            this.player1 = player;
            this.name = maze.Name;
            hasTwoPlayers = false;

        }

        /*
        * GetName - get name of maze
        */
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetName
        public string GetName()
        {
            return name;
        }

        /*
         * GetMaze - get the maze of the game
         */
        /// <summary>
        /// Gets the maze.
        /// </summary>
        /// <returns></returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GetMaze
        public Maze GetMaze()
        {
            //set name of maze
            maze.Name = name;
            
            return maze;
        }

        /*
         * SetPlayer - set second player
         */
        /// <summary>
        /// Sets the player.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for SetPlayer
        public void SetPlayer(TcpClient client)
        {
            player2 = client;
            hasTwoPlayers = true;            
        }

        /*
         * HasTwoPlayers - return boolean if two players are connected to game
         */
        /// <summary>
        /// Determines whether [has two players].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has two players]; otherwise, <c>false</c>.
        /// </returns>

        public bool HasTwoPlayers()
        {
            return hasTwoPlayers;
        }


        /*
         * getFirstPleyer - get second player
         */
        /// <summary>
        /// Gets the first pleyer.
        /// </summary>

        public TcpClient getFirstPleyer()
        {
            return player1;
        }

        /*
        * getFirstPleyer - get second player
        */
        /// <summary>
        /// Gets the second pleyer.
        /// </summary>
        /// <returns></returns>
        /// <autogeneratedoc />

        public TcpClient getSecondPleyer()
        {
            return player2;
        }


        /*
         * getOtherPleyer - get other player
         */
        /// <summary>
        /// Gets the other pleyer.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        /// <autogeneratedoc />

        public TcpClient getOtherPleyer(TcpClient client)
        {
            if (client == player1)
            {
                return player2;
            } 
            else if (client == player2)
            {
                return player1;
            }
            else
            {
                Console.WriteLine("this client is not in the game");
                return client;

            }
        }

    }
}
