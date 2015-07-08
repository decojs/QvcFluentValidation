namespace QvcFluentValidation.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentValidation;

    public static class Reflection
    {
        public static Dictionary<Type, Type> GetAllValidators(IReadOnlyCollection<Type> types)
        {
            return types
                .Where(type => type.BaseType != null
                        && type.BaseType.IsGenericType
                        && type.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                .ToDictionary(type => type.BaseType.GenericTypeArguments.First(), type => type);
        }

        public static Dictionary<Type, Type> GetAllValidationConstraintMappers(IReadOnlyCollection<Type> types)
        {
            var mappers = Qvc.Reflection.Reflection.GetImplementationsOfGenericInterface(typeof(IMapValidationConstraint<,>), types);

            return mappers.SelectMany(m => Qvc.Reflection.Reflection.GetFirstGenericArgumentFromInterfacesOfType(m, typeof(IMapValidationConstraint<,>)).Select(v => new { Mapper = m, Validator = v }))
                .ToDictionary(o => o.Validator, o => o.Mapper);
        } 
    }
}