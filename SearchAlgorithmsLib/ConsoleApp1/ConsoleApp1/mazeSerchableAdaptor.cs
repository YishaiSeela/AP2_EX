using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
using MazeLib;

namespace ConsoleApp1
{

    public class MazeSerchableAdaptor: ISearchable<Task>
    {
        //members
        public Maze maze;
        

        //constructor
        public MazeSerchableAdaptor()
        {
            this.maze = new Maze();
        }

        public MazeSerchableAdaptor(Maze maze)
        {
            this.maze = maze;
        }

        public List<State<Task>> getAllPossibleStates(State<Task> s)
        {
            int numRows;
            List<State<Task>> list = new List<State<Task>>();
            numRows = this.maze.Rows;
            for()
           
            throw new NotImplementedException();
        }

        public State<Task> getGoalState()
        {
            throw new NotImplementedException();
        }

        public State<Task> getInitialState()
        {
            throw new NotImplementedException();
        }
        
    }
}
