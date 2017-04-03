﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class State
    {
        private bool isVisited = false;
        private string state; // the state represented by a string
        private double cost; // cost to reach this state (set by a setter)
        private State cameFrom; // the state we came from to this state (setter)
        public State(string state) // CTOR
        {
            this.state = state;
        }
        public override bool Equals(object obj) // we override Object's Equals method
        {
            return state.Equals((obj as State).state);
        }
        public void setIsVisited(bool isVisited)
        {
            this.isVisited = isVisited;
        }
        public bool getIsVisited()
        {
            return isVisited;
        }
    }
