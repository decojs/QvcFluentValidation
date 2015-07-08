namespace QvcFluentValidation
{
    using System;
    using System.Threading.Tasks;

    using Qvc.Executables;
    using Qvc.Results;

    using QvcFluentValidation.Steps;

    public static class Action
    {
        public static Task<CommandAndType> Validate(ICommand command)
        {
            return Task.FromResult(new CommandAndType(command));
        }

        public static Task<QueryAndType> Validate(IQuery query)
        {
            return Task.FromResult(new QueryAndType(query));
        }

        public static ConstraintsResult Constraints(Type executable)
        {
            return new ConstraintsResult(null);
        }
    }
}