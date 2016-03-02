namespace QvcFluentValidation.Mappers
{
    using FluentValidation.Validators;

    using Qvc.Rules;

    using QvcFluentValidation.Mapping;

    public class MapPattern : IMapValidationConstraint<RegularExpressionValidator, Pattern>
    {
        public string Name
        {
            get { return "Pattern"; }
        }

        public Pattern CreateFrom(RegularExpressionValidator validator)
        {
            return new Pattern
            {
                Message = validator.ErrorMessageSource.GetString(),
                Regexp = validator.Expression,
                Flags = new string[] { }
            };
        }
    }
}