using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class DFS <T>: Searcher<T>
    {
        Solution<T> solution;

        public override Solution<T> search(ISearchable<T> searchable)
        {
            solution = new Solution<T>();
            Stack<State<T>> stack = new Stack<State<T>>();
            State<T> start = (searchable.getInitialState());
            if (start == searchable.getGoalState())
            {
                solution.addToSolution(start);
                return solution;
            }
            stack.Push(start);
            while (stack.Count() != 0)
            {
                State<T> v = stack.Pop();
                if (v.getCost() == 0)
                {
                    v.setCost(1);
                    List<State<T>> succerssors = searchable.getAllPossibleStates(v);
                    foreach (State<T> s in succerssors)
                    {
                        s.setPreviousState(v);

                        if (s == searchable.getGoalState())
                        {
                            solution = backTrace(s,solution);
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
