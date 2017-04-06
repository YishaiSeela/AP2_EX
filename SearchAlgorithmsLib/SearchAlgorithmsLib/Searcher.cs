using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher <T>: ISearcher<T>
    {
        private SimplePriorityQueue<State<T>> openList; 
        private int evaluatedNodes;
        public Searcher()
        {
            
            openList = new SimplePriorityQueue<State<T>>();
            evaluatedNodes = 0;
        }
        protected void addToOpenList(State<T> s,double priority)
        {
            s.setCost(priority);
            openList.Enqueue(s, (float) s.getCost());
        }

        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();
        }
        // a property of openList
        public int OpenListSize
        { 
            // it is a read-only property :)
            get { return openList.Count; }
        }
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        // check if an element exists in queue
        public bool isInQueue(State<T> s)
        {
            return openList.Contains(s);
        }
        // change pryority of item
        public void changePriority(State<T> s, double newPriority)
        {
            s.setCost(newPriority);
            openList.UpdatePriority(s, (float) newPriority);
        }

        public Solution<T> backTrace(State<T> n, Solution<T> solution)
        {

            solution.addToSolution(n);

            while (n.getPreviousState() != null)
            {
                n = n.getPreviousState();
                solution.addToSolution(n);

            }

            return solution;
        }

        public abstract Solution<T> search(ISearchable<T> searchable);
    }
}
