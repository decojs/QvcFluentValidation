namespace QvcFluentValidation.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentValidation;
    using FluentValidation.Validators;

    using Qvc;
    using Qvc.Constraints;
    using Qvc.Results;

    using QvcFluentValidation.Mapping;
    using QvcFluentValidation.Reflection;

    public static class FluentConstraintsSteps
    {
        public static ValidatorType FindValidatorFor(Type executable, Func<Type, Type> findValidatorType)
        {
            return new ValidatorType(findValidatorType(executable));
        }

        public static IValidator CreateValidator(
            ValidatorType self,
            Func<Type, IValidator> createValidator)
        {
            return self?.Type == null ? null : createValidator(self.Type);
        }

        public static ConstraintsAndMappers GetValidators(IValidator self, Func<IPropertyValidator, Type> getMapperFor)
        {
            if (self == null)
            {
                return new ConstraintsAndMappers(new List<ConstraintsAndMappers.Item>());
            }

            var parameters = self.CreateDescriptor()
                .GetMembersWithValidators()
                .Select(validators =>
                {
                    var constraints = validators
                        .Select(c => new ConstraintsAndMappers.Item.Entry(getMapperFor(c), c))
                        .Where(c => c.RuleGeneratorType != null)
                        .ToList();
                    return new ConstraintsAndMappers.Item(validators.Key, constraints);
                }).Where(p => p.Constraints.Any()).ToList();

            return new ConstraintsAndMappers(parameters);
        }

        public static ConstraintsResult GetConstraints(
            ConstraintsAndMappers self,
            Func<Type, IMapValidationConstraint> createMapper)
        {
            var parameters = self.Parameters.Select(p => 
                new Parameter(
                    p.Field.ToCamelCase(), 
                    p.Constraints
                    .Select(c => CreateConstraint(c, createMapper))
                    .Where(c => c != null)
                .ToList()))
                .ToList();
            return new ConstraintsResult(parameters);
        }

        private static Constraint CreateConstraint(ConstraintsAndMappers.Item.Entry entry, Func<Type, IMapValidationConstraint> createMapper)
        {
            var mapper = createMapper(entry.RuleGeneratorType);
            if (mapper == null)
            {
                return null;
            }

            var rule = Reflection.InvokeCreateFromMethod(entry.RuleGeneratorType, mapper, entry.PropertyValidator);
            return new Constraint(mapper.Name, rule);
        }
    }
}