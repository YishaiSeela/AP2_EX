using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
using MazeLib;

namespace Server
{

    public class MazeSearchableAdaptor : ISearchable<Position>
    {
        //members
        public Maze maze;
        /*
        * constructor for new maze
        */
        public MazeSearchableAdaptor()
        {
            this.maze = new Maze();
        }

        /*
        * constructor for existing maze
        */
        public MazeSearchableAdaptor(Maze maze)
        {
            this.maze = maze;
        }

        /*
        * GetPositionFromState - get coordinates of given state
        */
        public Position GetPositionFromState(State<Position> s)
        {
            string temp = s.ToString();
            string[] arr = temp.Split(',');
            string[] part = arr[0].Split('(');
            int i = Int32.Parse(part[1]);
            part = arr[1].Split(')');
            int j = Int32.Parse(part[0]);
            return new Position(i, j);
        }

        /*
        * getAllPossibleStates - get all possible neighbour states of a given state
        */
        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {
            int numRows = maze.Rows;
            int numCol = maze.Cols;

            List<State<Position>> list = new List<State<Position>>();
            Position position = GetPositionFromState(s);
            //if current state isn't in the first row
            if (0 <= position.Row - 1)
            {
                //if the state above current state is a free cell
                if (CellType.Free == maze[position.Row - 1, position.Col])
                {
                    Position new_position = new Position(position.Row - 1, position.Col);
                    State<Position> new_state = new State<Position>(new_position);
                    list.Add(new_state);
                }
            }
            //if current state isn't in the last row
            if (position.Row + 1 < numRows)
            {
                //if the state below current state is a free cell
                if (CellType.Free == maze[position.Row + 1, position.Col])
                {
                    Position new_position = new Position(position.Row + 1, position.Col);
                    State<Position> new_state = new State<Position>(new_position);
                    list.Add(new_state);
                }
            }
            //if current state isn't in the first coloumn
            if (0 <= position.Col - 1)
            {
                //if the state to the left of current state is a free cell
                if (CellType.Free == maze[position.Row, position.Col-1])
                {
                    Position new_position = new Position(position.Row, position.Col - 1);
                    State<Position> new_state = new State<Position>(new_position);
                    list.Add(new_state);
                }
            }
            //if current state isn't in the last coloumn
            if (position.Col + 1 < numCol)
            {
                //if the state to the right of current state is a free cell
                if (CellType.Free == maze[position.Row, position.Col + 1])
                    {
                        Position new_position = new Position(position.Row, position.Col + 1);
                        State<Position> new_state = new State<Position>(new_position);
                        list.Add(new_state);
                    }
            }
            
            return list;
        }

        /*
        * getGoalState - get goal state of maze
        */
        public State<Position> getGoalState()
        {
            return new State<Position>(maze.GoalPos);
        }

        /*
        * getInitialState - get initial state of maze
        */
        public State<Position> getInitialState()
        {
            return new State<Position>(maze.InitialPos);
        }
    }
}