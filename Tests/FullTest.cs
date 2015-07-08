namespace Tests
{
    using System.Threading.Tasks;

    using FluentValidation;
    using FluentValidation.Results;

    using NSubstitute;

    using NUnit.Framework;

    using Qvc;

    using QvcFluentValidation.Steps;

    using Shouldly;

    using Tests.TestMaterial;

    using Action = QvcFluentValidation.Action;

    [TestFixture]
    public class FullTest
    {
        private IValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = Substitute.For<IValidator>();
            _validator.ValidateAsync(Arg.Any<object>())
                .Returns(Task.FromResult(new ValidationResult()));
        }

        [Test]
        public async void TestValidateCommand()
        {
            var commandA = new CommandA();
            var result = await Action.Validate(commandA)
                .Then(c => CommandValidationSteps.FindValidator(c, t => typeof(IValidator)))
                .Then(c => CommandValidationSteps.CreateValidator(c, t => _validator))
                .Then(CommandValidationSteps.Validate);

            _validator.Received().ValidateAsync(commandA);

            result.ShouldBe(commandA);
        }

        [Test]
        public async void TestValidateQuery()
        {
            var queryA = new QueryA();
            var result = await Action.Validate(queryA)
                .Then(c => QueryValidationSteps.FindValidator(c, t => typeof(IValidator)))
                .Then(c => QueryValidationSteps.CreateValidator(c, t => _validator))
                .Then(QueryValidationSteps.Validate);

            _validator.Received().ValidateAsync(queryA);

            result.ShouldBe(queryA);
        }
    }
}
