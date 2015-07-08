namespace QvcFluentValidation.Steps
{
    using System;
    using System.Collections.Generic;

    using FluentValidation.Validators;

    public class ConstraintsAndMappers
    {
        public IReadOnlyCollection<Item> Parameters { get; set; }

        public ConstraintsAndMappers(IReadOnlyCollection<Item> parameters)
        {
            Parameters = parameters;
        }

        public class Item
        {
            public Item(string field, List<Entry> constraints)
            {
                Constraints = constraints;
                Field = field;
            }

            public List<Entry> Constraints { get; private set; }

            public string Field { get; private set; }

            public class Entry
            {
                public Entry(Type ruleGeneratorType, IPropertyValidator propertyValidator)
                {
                    RuleGeneratorType = ruleGeneratorType;
                    PropertyValidator = propertyValidator;
                }

                public Type RuleGeneratorType { get; private set; }

                public IPropertyValidator PropertyValidator { get; private set; }
            }
        }
    }
}