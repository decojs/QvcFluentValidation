using FluentValidation.Validators;

using Qvc.Rules;

namespace QvcFluentValidation.Mappers
{
    public class MapNotEmpty : IMapValidationConstraint<NotEmptyValidator, NotEmpty>
    {
        public string Name
        {
            get { return "NotEmpty"; }
        }

        public NotEmpty CreateFrom(NotEmptyValidator validator)
        {
            return new NotEmpty
            {
                Message = validator.ErrorMessageSource.GetString()
            };
        }
    }
}