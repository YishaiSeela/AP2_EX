using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class DFS : Searcher
    {
        Solution solution;

        public override Solution search(ISearchable searchable)
        {
            Stack<State> stack = new Stack<State>();
            State start = (searchable.getInitialState());
            if (start == searchable.getGoalState())
            {
                solution.addToSolution(start);
                return solution;
            }
            stack.Push(start);
            while (stack.Count() != 0)
            {
                State v = stack.Pop();
                if (v.getIsVisited() == false)
                {
                    v.setIsVisited(true);
                    List<State> succerssors = searchable.getAllPossibleStates(v);
                    foreach (State s in succerssors)
                    {
                        if (s == searchable.getGoalState())
                        {
                            foreach (State state in stack)
                            {
                                solution.addToSolution(state);
                            }
                            return solution;
                        }
                        stack.Push(s);
                    }
                }
            }
            return solution;
        }
    }
}
