namespace Tests.Steps
{
    using System.Linq;
    using System.Threading.Tasks;

    using FluentValidation;
    using FluentValidation.Results;

    using NSubstitute;

    using NUnit.Framework;

    using QvcFluentValidation.Steps;

    using Shouldly;

    using Tests.TestMaterial;

    [TestFixture]
    public class TestValidate
    {
        private IValidator _validValidator;

        private IValidator _invalidValidator;

        [SetUp]
        public void Setup()
        {
            _validValidator = Substitute.For<IValidator>();
            _invalidValidator = Substitute.For<IValidator>();

            _validValidator.ValidateAsync(Arg.Any<object>())
                .Returns(Task.FromResult(new ValidationResult()));

            _invalidValidator.ValidateAsync(Arg.Any<object>())
                .Returns(Task.FromResult(new ValidationResult(new[] { new ValidationFailure("FieldCamelCase", "error") })));
        }

        [Test]
        public async void TestCommandValid()
        {
            var command = new CommandA();
            var self = new CommandAndValidator(command, _validValidator);
            var result = await CommandValidationSteps.Validate(self);
            _validValidator.Received().ValidateAsync(command);
            result.ShouldBe(command);
        }

        [Test]
        public async void TestCommandNull()
        {
            var command = new CommandA();
            var self = new CommandAndValidator(command, null);
            var result = await CommandValidationSteps.Validate(self);
            result.ShouldBe(command);
        }

        [Test]
        public void TestCommandInvalid()
        {
            var command = new CommandA();
            var self = new CommandAndValidator(command, _invalidValidator);
            var result = Should.Throw<Qvc.Validation.ValidationException>(async () => await CommandValidationSteps.Validate(self));
            _invalidValidator.Received().ValidateAsync(command);

            result.Violations.Single().FieldName.ShouldBe("fieldCamelCase");
            result.Violations.Single().Message.ShouldBe("error");
        }

        [Test]
        public async void TestQueryValid()
        {
            var query = new QueryA();
            var self = new QueryAndValidator(query, _validValidator);
            var result = await QueryValidationSteps.Validate(self);
            _validValidator.Received().ValidateAsync(query);
            result.ShouldBe(query);
        }

        [Test]
        public async void TestQueryNull()
        {
            var query = new QueryA();
            var self = new QueryAndValidator(query, null);
            var result = await QueryValidationSteps.Validate(self);
            result.ShouldBe(query);
        }

        [Test]
        public void TestQueryInvalid()
        {
            var query = new QueryA();
            var self = new QueryAndValidator(query, _invalidValidator);
            var result = Should.Throw<Qvc.Validation.ValidationException>(async () => await QueryValidationSteps.Validate(self));
            _invalidValidator.Received().ValidateAsync(query);

            result.Violations.Single().FieldName.ShouldBe("fieldCamelCase");
            result.Violations.Single().Message.ShouldBe("error");
        }
    }
}