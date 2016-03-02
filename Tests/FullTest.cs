namespace Tests
{
    using System.Threading.Tasks;

    using FluentValidation;
    using NUnit.Framework;
    using Qvc;

    using QvcFluentValidation;
    using Shouldly;

    using Tests.TestMaterial;

    [TestFixture]
    public class FullTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestValidateCommand()
        {
            var commandA = new CommandA();
            var result = await Validate.Command(commandA)
                .ThenFindValidator(t => typeof(TestValidator))
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(commandA);
        }

        [Test]
        public async Task TestValidateQuery()
        {
            var queryA = new QueryA();
            var result = await Validate.Query(queryA)
                .ThenFindValidator(t => typeof(TestValidator))
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(queryA);
        }

        [Test]
        public async Task TestConstraints()
        {
            var result = await Task.FromResult(typeof(QueryA))
                .ThenFindValidator(t => typeof(TestValidator))
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenGetValidators(v => null)
                .ThenGetConstraints(v => null);
            result.Parameters.ShouldBeEmpty();
        }
    }
}
