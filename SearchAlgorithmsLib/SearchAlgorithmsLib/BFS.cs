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

        int priority = 0;
        int shortest;

        public override Solution<T> search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState(),priority); // inherited from Searcher

            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getGoalState()))
                {
                    shortest = priority;
                    backTrace(closed,n);
                    return solution;// private method, back traces through the parents
                                              // calling the delegated method, returns a list of states with n as a parent
                }
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                priority++;
                foreach (State<T> s in succerssors)
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

        public void backTrace(HashSet<State<T>> closed, State<T> n)
        {

            while (n.getPriorState() != null)
            {
                solution.addToSolution(n);
                n = n.getPriorState();
            }
        }

    }
}