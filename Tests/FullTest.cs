namespace Tests
{
    using System.Threading.Tasks;

    using FluentValidation;
    using FluentValidation.Results;

    using NSubstitute;

    using NUnit.Framework;

    using Qvc;

    using QvcFluentValidation;
    using QvcFluentValidation.Steps;

    using Shouldly;

    using Tests.TestMaterial;

    using Action = QvcFluentValidation.Action;

    [TestFixture]
    public class FullTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void TestValidateCommand()
        {
            var commandA = new CommandA();
            var result = await Action.Validate(commandA)
                .ThenFindValidator(t => typeof(TestValidator))
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(commandA);
        }

        [Test]
        public async void TestValidateQuery()
        {
            var queryA = new QueryA();
            var result = await Action.Validate(queryA)
                .ThenFindValidator(t => typeof(TestValidator))
                .ThenCreateValidator(t => Default.CreateHandler(t) as IValidator)
                .ThenValidate();

            result.ShouldBe(queryA);
        }
    }
}
