namespace QvcFluentValidation
{
    using System.Threading.Tasks;

    using Qvc.Executables;

    using QvcFluentValidation.Steps;

    public static class Validate
    {
        public static Task<CommandAndType> Command(ICommand command)
        {
            return Task.FromResult(new CommandAndType(command));
        }

        public static Task<QueryAndType> Query(IQuery query)
        {
            return Task.FromResult(new QueryAndType(query));
        }
    }
}