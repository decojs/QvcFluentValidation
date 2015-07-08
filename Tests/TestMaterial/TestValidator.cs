namespace Tests.TestMaterial
{
    using System;
    using System.Threading.Tasks;

    using FluentValidation;
    using FluentValidation.Results;

    public class TestValidator : IValidator
    {
        public ValidationResult Validate(object instance)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(object instance)
        {
            return Task.FromResult(new ValidationResult());
        }

        public ValidationResult Validate(ValidationContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(ValidationContext context)
        {
            throw new NotImplementedException();
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            throw new NotImplementedException();
        }

        public bool CanValidateInstancesOfType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}