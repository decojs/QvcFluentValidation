namespace QvcFluentValidation.Steps
{
    using FluentValidation;

    using Qvc.Executables;

    public class CommandAndValidator
    {
        public CommandAndValidator(ICommand command, IValidator validator)
        {
            Command = command;
            Validator = validator;
        }

        public ICommand Command { get; private set; }

        public IValidator Validator { get; private set; }
    }
}