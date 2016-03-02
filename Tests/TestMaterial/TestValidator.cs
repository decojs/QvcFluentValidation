using System.Collections.Generic;

namespace Tests.TestMaterial
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using FluentValidation;
    using FluentValidation.Results;

    public class TestValidator : IValidator
    {
        public ValidationResult Validate(object instance)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(object instance, CancellationToken cancellation = new CancellationToken())
        {
            return Task.FromResult(new ValidationResult());
        }

        public ValidationResult Validate(ValidationContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(ValidationContext context, CancellationToken cancellation = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            return new ValidatorDescriptor<QueryA>(new List<IValidationRule>());
        }

        public bool CanValidateInstancesOfType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}