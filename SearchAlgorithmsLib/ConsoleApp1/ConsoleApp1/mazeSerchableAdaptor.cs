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

        public List<State<CellType>> getAllPossibleStates(State<CellType> s)
        {
            int numRows = maze.Rows;
            int numCol = maze.Cols;
            int i, j;
            
            List<State<CellType>> list = new List<State<CellType>>();
            numRows = this.maze.Rows;
            for (i = 0; i < numRows; i++)
            {
                
                for (j = 0; j < numCol; j++)
                {
                    
                    list.Add(new State<CellType>(maze[i,j]));
                    
                }

            }

            throw new NotImplementedException();
        }

        public State<Task> getGoalState()
        {
            maze.GoalPos();
            throw new NotImplementedException();
        }

        public State<Task> getInitialState()
        {
            maze.InitialPos(0, 0);
            throw new NotImplementedException();
        }
        
    }
}
