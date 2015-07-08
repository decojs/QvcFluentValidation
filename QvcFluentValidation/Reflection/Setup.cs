namespace QvcFluentValidation.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Repository;

    public static class Setup
    {
        public static void SetupRepositories(
            ValidatorRepository validatorRepository, 
            MapperRepository mapperRepository, 
            IReadOnlyCollection<Type> types)
        {
            Reflection.GetAllValidators(types).ToList()
                .ForEach(p => validatorRepository.AddValidator(p.Key, p.Value));

            Reflection.GetAllValidationConstraintMappers(types).ToList()
                .ForEach(p => mapperRepository.AddMapper(p.Key, p.Value));
        }
    }
}