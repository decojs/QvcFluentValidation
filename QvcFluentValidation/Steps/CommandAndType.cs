namespace QvcFluentValidation.Steps
{
    using System;

    using Qvc.Executables;

    public class CommandAndType
    {
        public CommandAndType(ICommand command)
        {
            Command = command;
            Type = command.GetType();
        }

        public ICommand Command { get; private set; }

        public Type Type { get; private set; }
    }
}