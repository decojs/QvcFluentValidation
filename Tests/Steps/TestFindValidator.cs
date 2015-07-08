namespace Tests.Steps
{
    using NUnit.Framework;

    using QvcFluentValidation.Steps;

    using Shouldly;

    using Tests.TestMaterial;

    [TestFixture]
    public class TestFindValidator
    {
        [Test]
        public void TestCommand()
        {
            var command = new CommandA();
            var self = new CommandAndType(command);
            var result = CommandValidationSteps.FindValidator(
                self,
                t =>
                {
                    t.ShouldBe(self.Type);
                    return typeof(TestValidator);
                });
            result.ValidatorType.ShouldBe(typeof(TestValidator));
            result.Command.ShouldBe(command);
        }

        [Test]
        public void TestQuery()
        {
            var query = new QueryA();
            var self = new QueryAndType(query);
            var result = QueryValidationSteps.FindValidator(
                self,
                t =>
                {
                    t.ShouldBe(self.Type);
                    return typeof(TestValidator);
                });
            result.ValidatorType.ShouldBe(typeof(TestValidator));
            result.Query.ShouldBe(query);
        }

        [Test]
        public void TestCommandNull()
        {
            var command = new CommandA();
            var self = new CommandAndType(command);
            var result = CommandValidationSteps.FindValidator(
                self,
                t =>
                {
                    t.ShouldBe(self.Type);
                    return null;
                });
            result.ValidatorType.ShouldBe(null);
            result.Command.ShouldBe(command);
        }

        [Test]
        public void TestQueryNull()
        {
            var query = new QueryA();
            var self = new QueryAndType(query);
            var result = QueryValidationSteps.FindValidator(
                self,
                t =>
                {
                    t.ShouldBe(self.Type);
                    return null;
                });
            result.ValidatorType.ShouldBe(null);
            result.Query.ShouldBe(query);
        }
    }
}