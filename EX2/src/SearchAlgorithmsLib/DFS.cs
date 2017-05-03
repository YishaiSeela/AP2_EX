using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS<T> : Searcher<T>
    {
        Solution<T> solution;
        public override Solution<T> search(ISearchable<T> searchable)
        {
            solution = new Solution<T>();
            Stack<State<T>> stack = new Stack<State<T>>();
            State<T> start = (searchable.getInitialState());
            //if initial state is also the goal state - return it is solution
            if (start == searchable.getGoalState())
            {
                solution.addToSolution(start);
                return solution;
            }
            //else - push initial state to queue
            stack.Push(start);
            //while stack isn't empty - pop a state out of it
            while (stack.Count() != 0)
            {
                State<T> currentState = stack.Pop();

                //if cost is zero - state is undiscovered
                if (currentState.getCost() == 0)
                {
                    //set cost to 1 - state is discovered
                    currentState.setCost(1);
                    //get succesors
                    List<State<T>> succerssors = searchable.getAllPossibleStates(currentState);
                    foreach (State<T> s in succerssors)
                    {
                        //for each succesor (besides the initial state) - set it's previous state
                        if (s != searchable.getInitialState() && (s.getPreviousState() == null)) { 
                        s.setPreviousState(currentState);
                    }
                        //if a succesor is the goal state
                        if (s == searchable.getGoalState())
                        {
                            //backtrace path and return soloution
                            solution = backTrace(s, solution);
                            return solution;
                        }
                        //else - add suceesor to stack
                        stack.Push(s);
                    }
                }
            }

            //if stack is empty and no solution was found - return empty solution
            return solution;
        }

    }
}
