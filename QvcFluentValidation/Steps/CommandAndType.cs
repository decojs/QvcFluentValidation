namespace QvcFluentValidation.Steps
{
    using System;

    using Qvc.Executables;

    public class CommandAndType
    {
        public CommandAndType(ICommand command)
        {
            this.Command = command;
            this.Type = command.GetType();
        }

        public ICommand Command { get; private set; }

        public Type Type { get; private set; }
    }
}