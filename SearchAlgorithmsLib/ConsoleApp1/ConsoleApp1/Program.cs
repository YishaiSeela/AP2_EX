using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

()
namespace ConsoleApp1
{
    class Program
    {
        //members
        public DFSMazeGenerator mazeGenerator;
        public Solution<Task> sol;

        //create maze
        public void createMaze(DFSMazeGenerator mazeGenerator)
        {
            this.mazeGenerator = new DFSMazeGenerator();
            mazeGenerator.Generate(20, 20);
            throw  new NotImplementedException();
        }
        //print the maze
        public void printMaze()
        {
            System.Console.Write(mazeGenerator.ToString());
            throw new NotImplementedException();
        }
        public void solveBFS()
        {
            throw new NotImplementedException();
        }

        public void solveDFS()
        {
            throw new NotImplementedException();
        }
        public void printNumStatesBFS()
        {
            throw new NotImplementedException();
        }
        public void printNumStatesDFS()
        {
            throw new NotImplementedException();
        }

        public void CompareSolvers() {
            //create maze the size is: 20 on 20
            createMaze(mazeGenerator);
            //print the maze
            printMaze();
            //print solution BFS
            solveBFS();
            //print solution DFS
            solveDFS();
            //num of states in bfs
            printNumStatesBFS();
        }
        static void Main(string[] args)
        {
        }
    }
}
