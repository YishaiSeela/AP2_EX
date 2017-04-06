using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;
namespace ConsoleApp2
{
    class Program
    {
        static Position getPositionFromState(State<Position> s)
        {
            string temp = s.ToString();
            string[] arr = temp.Split(',');
            string[] part = arr[0].Split('(');
            int i = Int32.Parse(part[1]);
            part = arr[1].Split(')');
            int j = Int32.Parse(part[0]);
            return new Position(i, j);
        }

        static void Main(string[] args)
        {
            Position p = new Position(2, 4);
            State<Position> s = new State<Position>(p);
            Console.WriteLine(p);
            Console.WriteLine(s);
            Position p2 = getPositionFromState(s);
            Console.WriteLine(p2);
            Console.WriteLine(p.Equals(p2));
            State<Position> s2 = new State<Position>(p2);
            Console.WriteLine(s.Equals(s2));
        }
    }
}
