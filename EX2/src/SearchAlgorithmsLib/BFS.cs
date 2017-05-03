using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class BFS <T>: Searcher<T>
    {
        public Solution <T> solution;

        public override Solution<T> search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            solution = new Solution<T>();

            //add initial tate to open list
            addToOpenList(searchable.getInitialState(),0); // inherited from Searcher
            //create closed list
            HashSet<State<T>> closed = new HashSet<State<T>>();
            //while open list isn't empty
            while (OpenListSize > 0)
            {
                // inherited from Searcher, removes the best state
                State<T> currentState = popOpenList(); 
                closed.Add(currentState);
                //if a state is equeles to goal state - find soloution and save it
                if (currentState.Equals(searchable.getGoalState()))
                {
                    solution = backTrace(currentState, solution);

                }
                //get all succerssors of state
                List<State<T>> succerssors = searchable.getAllPossibleStates(currentState);
                foreach (State<T> s in succerssors)
                {
                    //if it's not in the open list and not in the closed list
                    if (!closed.Contains(s) && !isInQueue(s))
                    {
                        //set it's previous state and add it to list with it's cost
                        s.setPreviousState(currentState);
                        addToOpenList(s, currentState.getCost()+1);
                    }
                    else
                    {
                        //if current state has a lower cost than old cost
                        if (currentState.getCost()+1 < s.getCost())
                        {
                            //if it's not in the open list - add it
                            if (!isInQueue(s))
                            {
                                addToOpenList(s, currentState.getCost() + 1);
                            }
                            else
                            //else - change it's priority
                            {
                                changePriority(s, currentState.getCost() + 1);
                            }
                        }
   
                    }
                }
            }
            //return the cheapest solution
            return solution;
        }

    }
}