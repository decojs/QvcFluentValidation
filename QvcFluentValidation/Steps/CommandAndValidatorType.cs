namespace QvcFluentValidation.Steps
{
    using System;

    using Qvc.Executables;

    public class CommandAndValidatorType
    {
        public CommandAndValidatorType(ICommand command, Type validatorType)
        {
            Command = command;
            ValidatorType = validatorType;
        }

        public ICommand Command { get; private set; }

        public Type ValidatorType { get; private set; }
    }
}