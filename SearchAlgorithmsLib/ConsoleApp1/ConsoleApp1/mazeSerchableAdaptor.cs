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

    public class MazeSerchableAdaptor: ISearchable<T>
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

        private Position getPositionFromState(State<Position> s)
        {
            string temp = s.ToString();
            string[] arr = temp.Split(',');
            string[] part = arr[0].Split('(');
            int i = Int32.Parse(part[1]);
            part = arr[1].Split(')');
            int j = Int32.Parse(part[0]);
            return new Position(i, j);
        }

        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            int numRows = maze.Rows;
            int numCol = maze.Cols;
            
            List<State<Position>> list = new List<State<Position>>();
            Position position = getPositionFromState(s);
            if(0 <= position.Row - 1)
            {
                if (CellType.Free = maze[position.Row - 1, position.Col])
                {

                }
            }
            if (position.Row + 1 )
            {
                if (CellType.Free = maze[position.Row - 1, position.Col])
                {

                }
            }
            return list;
        }

        public State<Position> getGoalState()
        {
            return new State<Position>(maze);
            throw new NotImplementedException();
        }

        public State<Position> getInitialState()
        {
            //maze.InitialPos(0, 0);
            
            throw new NotImplementedException();
        }
        
    }
}

