using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_END = "Command";

        public string Read(string input)
        {
            var commands = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            var commandName = commands[0] + COMMAND_END;
            var cmdArg = commands.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type currentType = types.FirstOrDefault(t => t.Name == commandName);

            //if (currentType == null)
            //{
            //    throw new InvalidOperationException("Invalid command type.");
            //}

            Object instance = Activator.CreateInstance(currentType);
            ICommand command = (ICommand)instance;
            string result = command.Execute(cmdArg);

            return result;
        }
    }
}
