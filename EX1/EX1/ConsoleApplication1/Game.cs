using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Game
    {
        private Maze maze;
        private string name;
        private TcpClient player1;
        private TcpClient player2;
        private Boolean hasTwoPlayers;

        /*
         * constructor
         */
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
        public string GetName()
        {
            return name;
        }

        /*
         * GetMaze - get the maze of the game
         */
        public Maze GetMaze()
        {
            //set name of maze
            maze.Name = name;
            
            return maze;
        }

        /*
         * SetPlayer - set second player
         */
        public void SetPlayer(TcpClient client)
        {
            player2 = client;
            Console.WriteLine(hasTwoPlayers);
            hasTwoPlayers = true;            
        }

        /*
         * HasTwoPlayers - return boolean if two players are connected to game
         */
        public bool HasTwoPlayers()
        {
            return hasTwoPlayers;
        }

    }
}
