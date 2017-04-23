using MazeLib;
using SearchAlgorithmsLib;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Server
{
    public interface IModel
    {
        Maze GenerateMaze(string name, int rows, int cols);
        Solution<Position> SolveMaze(string name, int algorithem);
        void AddMaze(Maze maze);
        void AddGame(Game game);

        Dictionary<string,Game> GetGameList();
        bool doesMazeExist();

        int GetEvaluatedNodes();
        void RemoveGame(string removeGame);
    }
}