using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class BFS : Searcher
    {

        public override Solution search(ISearchable searchable)
        { // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); // inherited from Searcher

            HashSet<State> closed = new HashSet<State>();
            while (OpenListSize > 0)
            {
                State n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getIGoallState()))
                    return backTrace(closed); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State> succerssors = searchable.getAllPossibleStates(n);
                foreach (State s in succerssors)
                {
                    if (!closed.Contains(s) && !openContaines(s))
                    {
                        // s.setCameFrom(n); // already done by getSuccessors
                        addToOpenList(s);
                    }
                    else
                    {
                        Path p = this.path;
                        if (p.length() < best.length())
                        {
                            if (!openContaines(p))
                            {
                                addToOpenList(p);
                            }
                            else
                            {
                                Priority_Queue.add(p);
                            }
                        }
                    }
                }
            }
        }

        private Solution backTrace(HashSet<State> closed)
        {
            foreach (State s in closed)
            {
                Priority_Queue{
                }
            }

        }
    }
}