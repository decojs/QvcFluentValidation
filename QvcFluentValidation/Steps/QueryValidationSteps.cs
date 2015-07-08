namespace QvcFluentValidation.Steps
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentValidation;

    using Qvc;
    using Qvc.Executables;
    using Qvc.Validation;

    public static class QueryValidationSteps
    {
        public static QueryAndValidatorType FindValidator(QueryAndType self, Func<Type, Type> findValidatorType)
        {
            return new QueryAndValidatorType(self.Query, findValidatorType(self.Type));
        }

        public static QueryAndValidator CreateValidator(
            QueryAndValidatorType self,
            Func<Type, IValidator> createValidator)
        {
            var validator = self.ValidatorType == null
                                ? null
                                : createValidator(self.ValidatorType);
            return new QueryAndValidator(self.Query, validator);
        }

        public static async Task<IQuery> Validate(QueryAndValidator self)
        {
            if (self.Validator == null)
            {
                return self.Query;
            }

            var result = await self.Validator.ValidateAsync(self.Query);

            if (result.IsValid)
            {
                return self.Query;
            }

            var errors = result.Errors
                .Select(x => new Violation(x.PropertyName.ToCamelCase(), x.ErrorMessage))
                .ToList();

            throw new Qvc.Validation.ValidationException(errors);
        }
    }
}