using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class BFS : Searcher
    {
        Solution solution;

        int priority = 0;
        int shortest;

        public override Solution search(ISearchable searchable)
        { // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState(),priority); // inherited from Searcher

            HashSet<State> closed = new HashSet<State>();
            while (OpenListSize > 0)
            {
                State n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getGoalState()))
                {
                    shortest = priority;
                    return backTrace(closed); // private method, back traces through the parents
                                              // calling the delegated method, returns a list of states with n as a parent
                }
                List<State> succerssors = searchable.getAllPossibleStates(n);
                priority++;
                foreach (State s in succerssors)
                {
                    if (!closed.Contains(s) && !isInQueue(s))
                    {
                        // s.setCameFrom(n); // already done by getSuccessors
                        addToOpenList(s,priority);
                    }
                    else
                    {
                        if (priority < shortest)
                        {
                            if (!isInQueue(s))
                            {
                                addToOpenList(s, priority);
                            }
                            else
                            {
                                changePriority(s, priority);
                            }
                        }
   
                    }
                }
            }
            return solution;
        }
    }
}