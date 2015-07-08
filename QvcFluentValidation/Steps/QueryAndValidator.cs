namespace QvcFluentValidation.Steps
{
    using FluentValidation;

    using Qvc.Executables;

    public class QueryAndValidator
    {
        public QueryAndValidator(IQuery query, IValidator validator)
        {
            Query = query;
            Validator = validator;
        }

        public IQuery Query { get; private set; }

        public IValidator Validator { get; private set; }
    }
}