namespace QvcFluentValidation.Repository
{
    using System;
    using System.Collections.Generic;

    public class ValidatorRepository
    {
        readonly Dictionary<Type, Type> _validatorLookup;

        public ValidatorRepository()
        {
            _validatorLookup = new Dictionary<Type, Type>();
        }

        public Type FindValidatorFor(Type executable)
        {
            return _validatorLookup.ContainsKey(executable)
                ? _validatorLookup[executable]
                : null;
        }

        public void AddValidator(Type executable, Type validator)
        {
            _validatorLookup.Add(executable, validator);
        }
    }
}