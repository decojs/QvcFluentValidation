namespace QvcFluentValidation.Steps
{
    using System;

    using Qvc.Executables;

    public class QueryAndType
    {
        public QueryAndType(IQuery query)
        {
            Query = query;
            Type = query.GetType();
        }

        public IQuery Query { get; set; }

        public Type Type { get; set; }
    }
}