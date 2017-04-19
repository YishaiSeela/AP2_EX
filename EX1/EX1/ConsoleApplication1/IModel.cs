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

        List<Game> GetGameList();
        int GetEvaluatedNodes();
        void RemoveGame(Game correctGame);
    }
}