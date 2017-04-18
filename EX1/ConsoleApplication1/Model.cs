using ConsoleApp1;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal class Model : IModel
    {
        //members
        private DFSMazeGenerator mazeGenerator;
        private Solution<Position> solBFS;
        private Solution<Position> solDFS;
        private int nodesEvaluated;
        private Maze maze;
        private Maze correct;
        private List<Maze> mazes = new List<Maze>();

        /*
        * GenerateMaze - create the maze
        */
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            //this.mazeGenerator = new DFSMazeGenerator();
            maze = mazeGenerator.Generate(rows, cols);
            mazes.Add(maze);
            return maze;
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
            //find the maze to solve
            foreach (Maze maze in mazes)
            {
                //if a maze with the same name was found - save it
                if (maze.Name == name)
                {
                    correct = maze;
                }
            }
            //if maze wasn't found - throw exception
            if (correct == null)
            {
                throw new Exception("maze dosn't exist");
            }

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