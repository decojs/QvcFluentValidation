using System;
using System.Collections.Generic;
using System.Linq;

using FluentValidation;
using FluentValidation.Validators;

using Qvc;
using Qvc.Constraints;
using Qvc.Executables;
using Qvc.Results;
using Qvc.Validation;


namespace QvcFluentValidation
{
    public class Validation
    {
        /*ConstraintsResult GetConstraintsFor(Type executable)
        {
            var validator = GetValidatorFor(executable);
            if (validator == null)
            {
                return new ConstraintsResult(new List<Parameter>());
            }

            var parameters = validator.CreateDescriptor()
                .GetMembersWithValidators()
                .Select(validators =>
                {
                    var constraints = validators
                        .Select(ConstraintFor)
                        .Where(c => c != null)
                        .ToList();

                    return new Parameter(validators.Key.ToCamelCase(), constraints);
                })
                    .Where(p => p.Constraints.Any());
            return new ConstraintsResult(parameters.ToList());
        }

        Constraint ConstraintFor(IPropertyValidator v)
        {
            var ruleGeneratorType = _qvcLookup.FindConstraintGeneratorFor(v.GetType());

            if (ruleGeneratorType == null)
            {
                return null;
            }

            var ruleGenerator = DependencyResolver.Current.GetService(ruleGeneratorType) as IMapValidationConstraint;

            if (ruleGenerator == null)
            {
                return null;
            }

            var rule = ruleGeneratorType.GetMethod("CreateFrom").Invoke(ruleGenerator, new object[] { v }) as IRule;
            return new Constraint(ruleGenerator.Name, rule);
        }

        IValidator GetValidatorFor(Type executable)
        {
            var validatorType = _qvcLookup.FindValidatorFor(executable);
            if (validatorType == null)
            {
                return null;
            }

            return DependencyResolver.Current.GetService(validatorType) as IValidator;
        } */
    }
}