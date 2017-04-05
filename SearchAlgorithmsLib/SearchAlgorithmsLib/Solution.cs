using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {
        List<State<T>> solutionList = new List<State<T>>();

        public void addToSolution(State<T> state)
        {
            solutionList.Add(state);
        }

        public int count()
        {
            return solutionList.Count;
        }

        public State<T> getState(int index)
        {
            return solutionList[index];
        }

    }
}
