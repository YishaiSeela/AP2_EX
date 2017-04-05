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
                if (v.getIsVisited() == false)
                {
                    v.setIsVisited(true);
                    List<State<T>> succerssors = searchable.getAllPossibleStates(v);
                    foreach (State<T> s in succerssors)
                    {
                        if (s == searchable.getGoalState())
                        {
                            foreach (State<T> state in stack)
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
