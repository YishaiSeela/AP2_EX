using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace ConsoleApp1
{
    class Program
    {
        //members
        public DFSMazeGenerator mazeGenerator;
        public Solution<Position> solBFS;
        public Solution<Position> solDFS;

        //create maze
        public Maze createMaze(DFSMazeGenerator mazeGenerator)
        {
            this.mazeGenerator = new DFSMazeGenerator();
            return mazeGenerator.Generate(20, 20);
        }
        //print the maze
        public void printMaze(Maze maze)
        {
            System.Console.Write(maze.ToString());
        }
        public void solveBFS(Maze maze)
        {
            ISearchable<Position> mazeSearch = new MazeSerchableAdaptor(maze);
            BFS<Position> bfs = new BFS<Position>();
            solBFS = bfs.search(mazeSearch);
        }

        public void solveDFS(Maze maze)
        {
            ISearchable<Position> mazeSearch = new MazeSerchableAdaptor(maze);
            DFS<Position> dfs = new DFS<Position>();
            solDFS = dfs.search(mazeSearch);
        }
        public void printNumStatesBFS(Maze maze)
        {
            System.Console.Write(solBFS.count());
        }
        public void printNumStatesDFS(Maze maze)
        {
            System.Console.Write(solDFS.count());
        }

        public void CompareSolvers() {
           
            Maze maze = createMaze(mazeGenerator);
            //print the maze
            printMaze(maze);
            //print solution BFS
            solveBFS(maze);
            //print solution DFS
            solveDFS(maze);
            //num of states in bfs
            printNumStatesBFS(maze);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.CompareSolvers();
            
        }
    }
}
