namespace QvcFluentValidation
{
    using System;
    using System.Threading.Tasks;

    using FluentValidation;
    using FluentValidation.Validators;

    using Qvc.Constraints;
    using Qvc.Results;

    using QvcFluentValidation.Mapping;
    using QvcFluentValidation.Steps;

    public static class ConstraintsExtensions
    {
        public static async Task<ValidatorType> ThenFindValidator(this Task<Type> executable, Func<Type, Type> validatorTypeFor)
        {
            return FluentConstraintsSteps.FindValidatorFor(await executable, validatorTypeFor);
        }

        public static async Task<IValidator> ThenCreateValidator(
            this Task<ValidatorType> validatorType,
            Func<Type, IValidator> createValidator)
        {
            return FluentConstraintsSteps.CreateValidator(await validatorType, createValidator);
        }

        public static async Task<ConstraintsAndMappers> ThenGetValidators(
            this Task<IValidator> self,
            Func<IPropertyValidator, Type> getMapperFor)
        {
            return FluentConstraintsSteps.GetValidators(await self, getMapperFor);
        }

        public static async Task<ConstraintsResult> ThenGetConstraints(this Task<ConstraintsAndMappers> validator, Func<Type, IMapValidationConstraint> createMapper)
        {
            return FluentConstraintsSteps.GetConstraints(await validator, createMapper);
        }
    }
}