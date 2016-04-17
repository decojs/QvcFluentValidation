namespace Tests
{
    using System.Threading.Tasks;

    using FluentValidation;

    using NUnit.Framework;

    using Qvc;

    using QvcFluentValidation;

    using Shouldly;

    using Tests.TestMaterial;
    using QvcFluentValidation.Repository;
    [TestFixture]
    public class FullTest
    {
        private ValidatorRepository _validatorRepo;

        [SetUp]
        public void Setup()
        {
            _validatorRepo = new ValidatorRepository();
            _validatorRepo.AddValidator(typeof(CommandA), typeof(TestValidator<CommandA>));
            _validatorRepo.AddValidator(typeof(QueryA), typeof(TestValidator<CommandB>));
        }

        [Test]
        public async Task TestValidateCommand()
        {
            var commandA = new CommandA();
            var result = await Validate.Command(commandA)
                .ThenFindValidator(_validatorRepo.FindValidatorFor)
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(commandA);
        }

        [Test]
        public async Task TestValidateQuery()
        {
            var queryA = new QueryA();
            var result = await Validate.Query(queryA)
                .ThenFindValidator(_validatorRepo.FindValidatorFor)
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(queryA);
        }

        [Test]
        public async Task TestConstraints()
        {
            var result = await Task.FromResult(typeof(QueryA))
                .ThenFindValidator(_validatorRepo.FindValidatorFor)
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenGetValidators(v => null)
                .ThenGetConstraints(v => null);
            result.Parameters.ShouldBeEmpty();
        }

        [Test]
        public async Task TestValidateCommandWithoutValidator()
        {
            var commandB = new CommandB();
            var result = await Validate.Command(commandB)
                .ThenFindValidator(_validatorRepo.FindValidatorFor)
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(commandB);
        }

        [Test]
        public async Task TestValidateQueryWithoutValidator()
        {
            var queryB = new QueryB();
            var result = await Validate.Query(queryB)
                .ThenFindValidator(_validatorRepo.FindValidatorFor)
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(queryB);
        }

        [Test]
        public async Task TestConstraintsWithoutValidator()
        {
            var result = await Task.FromResult(typeof(QueryB))
                .ThenFindValidator(_validatorRepo.FindValidatorFor)
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenGetValidators(v => null)
                .ThenGetConstraints(v => null);
            result.Parameters.ShouldBeEmpty();
        }
    }
}
