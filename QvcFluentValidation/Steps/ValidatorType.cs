namespace QvcFluentValidation.Steps
{
    using System;

    public class ValidatorType
    {
        public ValidatorType(Type validatorType)
        {
            Type = validatorType;
        }

        public Type Type { get; private set; }
    }
}