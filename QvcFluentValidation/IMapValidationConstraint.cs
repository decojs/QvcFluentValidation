namespace QvcFluentValidation
{
    using FluentValidation.Validators;
    using Qvc.Constraints;

    public interface IMapValidationConstraint<in TValidator, out TRule> : IMapValidationConstraint
        where TValidator : IPropertyValidator
        where TRule : IRule
    {
        TRule CreateFrom(TValidator validator);
    }

    public interface IMapValidationConstraint
    {
        string Name { get; }
    }
}