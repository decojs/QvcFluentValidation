using FluentValidation.Validators;

using Qvc.Rules;

namespace QvcFluentValidation.Mappers
{
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
                Regex = validator.Expression,
                Flags = new string[] { }
            };
        }
    }
}