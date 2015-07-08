namespace QvcFluentValidation.Steps
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using FluentValidation;

    using Qvc;
    using Qvc.Executables;
    using Qvc.Validation;

    public static class CommandValidationSteps
    {
        public static CommandAndValidatorType FindValidator(CommandAndType self, Func<Type, Type> findValidatorType)
        {
            return new CommandAndValidatorType(self.Command, findValidatorType(self.Type));
        }

        public static CommandAndValidator CreateValidator(
            CommandAndValidatorType self,
            Func<Type, IValidator> createValidator)
        {
            var validator = self.ValidatorType == null
                ? null
                : createValidator(self.ValidatorType);
            return new CommandAndValidator(self.Command, validator);
        }

        public static async Task<ICommand> Validate(CommandAndValidator self)
        {
            if (self.Validator == null)
            {
                return self.Command;
            }

            var result = await self.Validator.ValidateAsync(self.Command);

            if (result.IsValid)
            {
                return self.Command;
            }

            var errors = result.Errors
                .Select(x => new Violation(x.PropertyName.ToCamelCase(), x.ErrorMessage))
                .ToList();

            throw new Qvc.Validation.ValidationException(errors);
        }
    }
}