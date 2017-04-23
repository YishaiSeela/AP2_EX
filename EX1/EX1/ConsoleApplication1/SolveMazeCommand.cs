using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using System.Net;
using System.Net.Sockets;
using SearchAlgorithmsLib;
using Server;
using Newtonsoft.Json.Linq;

namespace Server
{
    class SolveMazeCommand : ICommand
    {
        private IModel model;
        private MazeSearchableAdaptor msa = new MazeSearchableAdaptor();
        
        /*
        * Constructor
        */
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }

        /*
        * SolutionString - get solutioon of movements in maze
        */
        public string SolutionString(Solution<Position> solution)
        {
            string sol = "";

            if (solution != null)
            {
                //compare every state in solution with its previous
                for (int i = 1; i < solution.count(); i++)
                {
                    //if previous state coloumn coordinate is lower by 1 than current state - moved right(1)
                    
                    if (msa.GetPositionFromState(solution.getState(i - 1)).Col -
                        msa.GetPositionFromState(solution.getState(i)).Col == 1)
                    {
                        sol = "1" +sol;
                    }
                    //if previous state coloumn coordinate is higher by 1 than current state - moved left(0)
                    else if (msa.GetPositionFromState(solution.getState(i)).Col -
                        msa.GetPositionFromState(solution.getState(i - 1)).Col == 1)
                    {
                        sol = "0" + sol;
                    }
                    //if previous state row coordinate is lower by 1 than current state - moved down(3)
                    else if (msa.GetPositionFromState(solution.getState(i - 1)).Row -
                        msa.GetPositionFromState(solution.getState(i)).Row == 1)
                    {
                        sol = "3" + sol;
                    }
                    //if previous state row coordinate is higher by 1 than current state - moved up(2)
                    else if (msa.GetPositionFromState(solution.getState(i)).Row -
                        msa.GetPositionFromState(solution.getState(i - 1)).Row == 1)
                    {
                        sol = "2" + sol;
                    }
                }
            }
            return sol;
        }

        /*
        * ToJSON - get JSON string of maze solution
        */

        public string ToJSON(string name, string solutionStr, int nodesEvaluated)
        {

            JObject mazeObj = new JObject();
            mazeObj["Name"] = name;
            mazeObj["Solution"] = solutionStr;
            mazeObj["NodesEvaluated"] = nodesEvaluated;

            return mazeObj.ToString();
        }

        /*
        * Execute - solve maze
        */
        public string Execute(string[] args, TcpClient client)
        {
            //name of maze
            string name = args[0];
            //algorithm of solution (bfs-0,dfs-1)
            int algorithem = int.Parse(args[1]);
            //solve maze
            Solution<Position> solution = model.SolveMaze(name, algorithem);
            //get number of nodes evaluated
            int nodesEvaluated = model.GetEvaluatedNodes();
            //get string of solution
            string solutionStr = SolutionString(solution);

            //find the maze to solve

            if (model.doesMazeExist())
            {

                //retuen JSON string
                return ToJSON(name, solutionStr, nodesEvaluated);
            }
            else
            {
                return "maze dosn't exist\n";
            }
        }
    }
}
