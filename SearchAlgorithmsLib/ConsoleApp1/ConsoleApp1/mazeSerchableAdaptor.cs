﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using SearchAlgorithmsLib;
using MazeLib;

namespace ConsoleApp1
{
    public class mazeSerchableAdaptor: ISearchable<Task>
    {
        
       Maze maze;

       

        public List<State<Task>> getAllPossibleStates(State<Task> s)
        {
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
        public Maze
    }
}
