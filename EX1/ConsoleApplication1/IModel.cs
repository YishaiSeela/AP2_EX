using MazeLib;
using SearchAlgorithmsLib;

namespace ConsoleApplication1
{
    internal interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);
        Solution<Position> SolveMaze(string name, int algorithem);
        int GetEvaluatedNodes();
    }
}