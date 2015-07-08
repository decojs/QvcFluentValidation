namespace QvcFluentValidation
{
    using System;
    using System.Threading.Tasks;

    using FluentValidation;

    using Qvc.Executables;

    using QvcFluentValidation.Steps;

    public static class QueryValidationExtensions
    {
        public static async Task<QueryAndValidatorType> ThenFindValidator(this Task<QueryAndType> self, Func<Type, Type> findValidatorType)
        {
            return QueryValidationSteps.FindValidator(await self, findValidatorType);
        }

        public static async Task<QueryAndValidator> ThenCreateValidator(
            this Task<QueryAndValidatorType> self,
            Func<Type, IValidator> createValidator)
        {
            return QueryValidationSteps.CreateValidator(await self, createValidator);
        }

        public static async Task<IQuery> ThenValidate(this Task<QueryAndValidator> self)
        {
            return await QueryValidationSteps.Validate(await self);
        }
    }
}