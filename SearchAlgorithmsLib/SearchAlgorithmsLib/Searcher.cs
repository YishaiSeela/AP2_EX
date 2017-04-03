using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher : ISearcher
    {
        private SimplePriorityQueue<State> openList; 
        private int evaluatedNodes;
        public Searcher()
        {
            
            openList = new SimplePriorityQueue<State>();
            evaluatedNodes = 0;
        }
        protected void addToOpenList(State s,int priority)
        {
            openList.Enqueue(s,priority);
        }

        protected State popOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();
        }
        // a property of openList
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        // check if an element exists in queue
        public bool isInQueue(State s)
        {
            return openList.Contains(s);
        }
        // change pryority of item
        public void changePriority(State s, int newPriority)
        {
            openList.UpdatePriority(s, newPriority);
        }
        public abstract Solution search(ISearchable searchable);
    }
}
