using Server;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;

namespace Server
{
    public class Model : IModel
    {
        //members
        private DFSMazeGenerator mazeGenerator;
        private Solution<Position> solBFS;
        private Solution<Position> solDFS;
        private int nodesEvaluated;
        private Maze maze;
        private Maze correct;
        private List<Maze> mazes = new List<Maze>();
        private Dictionary<string, Game> games = new Dictionary<string, Game>();
        private Dictionary<string, Game> playedGames = new Dictionary<string, Game>();
        private Boolean mazeExists;



        /*
        * GenerateMaze - create the maze
        */
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            mazeGenerator = new DFSMazeGenerator();
            //this.mazeGenerator = new DFSMazeGenerator();
            maze = mazeGenerator.Generate(rows, cols);
            return maze;
        }

        /*
        * AddMaze - add maze to list of mazes
        */
        public void AddMaze(Maze maze)
        {
            mazes.Add(maze);
        }

        /*
         * AddGame - add game to list of games
         */
        public void AddGame(Game game)
        {
                
            games.Add(game.GetName(),game);

        }


        /*
        * PrintMaze - print the maze
        */
        public void PrintMaze(Maze maze)
        {
            System.Console.Write(maze.ToString());
        }

        /*
        * SolveMaze - solve the maze
        */
        public Solution<Position> SolveMaze(string name, int algorithem)
        {

            //initialize correct maze to null before lookin for maze to solve
            correct = null;

            //find the maze to solve
            foreach (Maze maze in mazes)
            {
                //if a maze with the same name was found - save it
                if (maze.Name == name)
                {
                    correct = maze;
                    mazeExists = true;
                }
            }
            //if maze wasn't found - throw exception
            if (correct == null)
            {
                Console.WriteLine("maze dosn't exist");
                mazeExists = false;
                return null;
            }
            else
            {

                ISearchable<Position> mazeSearch = new MazeSearchableAdaptor(correct);
                //if algorithm no. is 0 - solve maze by BFS
                if (algorithem == 0)
                {
                    BFS<Position> bfs = new BFS<Position>();
                    solBFS = bfs.search(mazeSearch);
                    nodesEvaluated = bfs.getNumberOfNodesEvaluated();
                    return solBFS;
                }
                //if algorithm no. is 1 - solve maze by DFS
                else
                {
                    DFS<Position> dfs = new DFS<Position>();
                    solDFS = dfs.search(mazeSearch);
                    nodesEvaluated = dfs.getNumberOfNodesEvaluated();
                    return solDFS;

                }
            }
        }

        /*
        * GetGameList - get list of games
        */
        public Dictionary<string, Game> GetGameList()
        {
            return games;
        }

        /*
        * GetMazeList - get list of mazes
        */
        public bool doesMazeExist()
        {
            return mazeExists;
        }

        /*
        * RemoveGame - remove game from list
        */
        public void RemoveGame(string removeGame)
        {
            GetGameList().Remove(removeGame);
        }


        /*
        * PrintNumStatesBFS - print no. of nodes evaluated by BFS
        */
        public void PrintNumStatesBFS(Maze maze)
        {
            Console.WriteLine("Nodes evalueated by BFS: " + nodesEvaluated);
        }

        /*
        * PrintNumStatesDFS - print no. of nodes evaluated by DFS
        */
        public void PrintNumStatesDFS(Maze maze)
        {
            Console.WriteLine("Nodes evalueated by DFS: " + nodesEvaluated);
        }

        /*
        * GetEvaluatedNodes - return no. of nodes evaluated
        */
        public int GetEvaluatedNodes()
        {
            return nodesEvaluated;
        }


    }
}