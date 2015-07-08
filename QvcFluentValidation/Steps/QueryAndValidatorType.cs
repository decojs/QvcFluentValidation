namespace QvcFluentValidation.Steps
{
    using System;

    using Qvc.Executables;

    public class QueryAndValidatorType
    {
        public QueryAndValidatorType(IQuery query, Type validatorType)
        {
            this.Query = query;
            this.ValidatorType = validatorType;
        }

        public IQuery Query { get; private set; }

        public Type ValidatorType { get; private set; }
    }
}