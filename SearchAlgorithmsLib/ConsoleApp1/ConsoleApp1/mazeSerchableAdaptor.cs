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

    public class MazeSerchableAdaptor : ISearchable<Position>
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
            if (0 <= position.Row - 1)
            {
                if (CellType.Free == maze[position.Row - 1, position.Col])
                {
                    Position new_position = new Position(position.Row - 1, position.Col);
                    State<Position> new_state = new State<Position>(new_position);
                    list.Add(new_state);
                }
            }
            if (position.Row + 1 < numRows)
            {
                if (CellType.Free == maze[position.Row + 1, position.Col])
                {
                    Position new_position = new Position(position.Row + 1, position.Col);
                    State<Position> new_state = new State<Position>(new_position);
                    list.Add(new_state);
                }
            }
            if (0 <= position.Col - 1)
            {
                if (CellType.Free == maze[position.Col - 1, position.Col])
                {
                    Position new_position = new Position(position.Row, position.Col - 1);
                    State<Position> new_state = new State<Position>(new_position);
                    list.Add(new_state);
                }
                if (position.Col + 1 < numCol)
                {
                    if (CellType.Free == maze[position.Row, position.Col + 1])
                    {
                        Position new_position = new Position(position.Row, position.Col+1);
                        State<Position> new_state = new State<Position>(new_position);
                        list.Add(new_state);
                    }
                }
            }
            return list;
        }

        public State<Position> getGoalState()
        {
            return new State<Position>(maze.GoalPos);

        }

        public State<Position> getInitialState()
        {

            return new State<Position>(maze.InitialPos);
        }
    }
}

