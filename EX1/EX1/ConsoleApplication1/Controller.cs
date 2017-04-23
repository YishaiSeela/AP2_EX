
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public class Controller
    {

        //list of commands for multiplayer
        private List<string> multiCommands = new List<string>();
        private Dictionary<string, ICommand> commands;
        private IModel model;
        private bool isMulti;
        public Controller()
        {
            multiCommands.Add("play");
            multiCommands.Add("join");
            multiCommands.Add("start");

            Model model = new Model();
            commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(model));
            commands.Add("solve", new SolveMazeCommand(model));
            commands.Add("start", new StartGameCommand(model));
            commands.Add("list",new ShowListCommand(model));
            commands.Add("join", new JoinGameCommand(model));
            commands.Add("play", new PlayCommand(model));
            commands.Add("close", new CloseCommand(model));

        }
        public string ExecuteCommand(string commandLine, TcpClient client)
        {
            isMulti = false;
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            if (multiCommands.Contains(commandKey))
            {
                isMulti = true;
            }
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, client);
        }

        public bool isMultiCommand()
        {
            return isMulti;
        }
    }

}