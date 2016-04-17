using System.Collections.Generic;

namespace Tests.TestMaterial
{
    using System;
    using System.Threading.Tasks;

    using FluentValidation;
    using FluentValidation.Results;

    public class TestValidator<T> : IValidator
    {
        public ValidationResult Validate(object instance)
        {
            return new ValidationResult();
        }

        public Task<ValidationResult> ValidateAsync(object instance)
        {
            return Task.FromResult(new ValidationResult());
        }

        public ValidationResult Validate(ValidationContext context)
        {
            return new ValidationResult();
        }

        public Task<ValidationResult> ValidateAsync(ValidationContext context)
        {
            return Task.FromResult(new ValidationResult());
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            return new ValidatorDescriptor<T>(new List<IValidationRule>());
        }

        public bool CanValidateInstancesOfType(Type type)
        {
            return true;
        }
    }
}