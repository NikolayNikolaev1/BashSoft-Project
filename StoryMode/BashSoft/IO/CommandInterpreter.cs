namespace BashSoft
{
    using Attributes;
    using Contracts;
    using IO.Commands;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            Type typeOfCommand = 
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                            .Where(atr => atr.Equals(command))
                            .ToArray().Length > 0);

            Type typeofInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter = typeofInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter
                            .First(x => x.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}
