
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{


    /// <summary>
    /// this class contain the list of commands for multiplayer
    /// </summary>

    public class Controller
    {

        private List<string> multiCommands = new List<string>();
        /// <summary>
        /// The commands</summary>
  
        private Dictionary<string, ICommand> commands;
        /// <summary>
        /// The model
        /// </summary>
        /// 
        private IModel model;
        /// <summary>
        /// The is multi
        /// </summary>

        private bool isMulti;
        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>

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
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <param name="client">The client.</param>
        /// <returns> command/returns>

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

        /// <summary>
        /// Determines whether [is multi command].
        /// </summary>
        /// <returns>
        ///<c>true</c> if [is multi command]; otherwise, <c>false</c>.

        public bool isMultiCommand()
        {
            return isMulti;
        }
    }

}