namespace QvcFluentValidation
{
    using System;
    using System.Threading.Tasks;

    using FluentValidation;

    using Qvc.Executables;

    using QvcFluentValidation.Steps;

    public static class CommandValidationExtensions
    {
        public static async Task<CommandAndValidatorType> ThenFindValidator(this Task<CommandAndType> self, Func<Type, Type> findValidatorType)
        {
            return CommandValidationSteps.FindValidator(await self, findValidatorType);
        }

        public static async Task<CommandAndValidator> ThenCreateValidator(
            this Task<CommandAndValidatorType> self,
            Func<Type, IValidator> createValidator)
        {
            return CommandValidationSteps.CreateValidator(await self, createValidator);
        }

        public static async Task<ICommand> ThenValidate(this Task<CommandAndValidator> self)
        {
            return await CommandValidationSteps.Validate(await self);
        }
    }
}