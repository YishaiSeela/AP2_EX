using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class BFS <T>: Searcher<T>
    {
        Solution <T> solution;

        int cost = 0;

        public override Solution<T> search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            solution = new Solution<T>();

            addToOpenList(searchable.getInitialState(),0); // inherited from Searcher

            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (OpenListSize > 0)
            {
                State<T> n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getGoalState()))
                {
                    solution = backTrace(n, solution);
                    //return solution;// private method, back traces through the parents
                                             // calling the delegated method, returns a list of states with n as a parent
                }
                List<State<T>> succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    if (!closed.Contains(s) && !isInQueue(s))
                    {
                        // s.setCameFrom(n); // already done by getSuccessors
                        s.setPreviousState(n);
                        addToOpenList(s,n.getCost()+1);
                    }
                    else
                    {
                        if (n.getCost()+1 < s.getCost())
                        {
                            if (!isInQueue(s))
                            {
                                addToOpenList(s, n.getCost() + 1);
                            }
                            else
                            {
                                changePriority(s, n.getCost() + 1);
                            }
                        }
   
                    }
                }
            }
            return solution;
        }

    }
}