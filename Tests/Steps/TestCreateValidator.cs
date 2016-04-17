using Qvc.Steps;

namespace Tests.Steps
{
    using System;

    using FluentValidation;

    using NSubstitute;

    using NUnit.Framework;

    using QvcFluentValidation.Steps;

    using Shouldly;

    using Tests.TestMaterial;

    [TestFixture]
    public class TestCreateValidator
    {
        [Test]
        public void TestCommand()
        {
            var command = new CommandA();
            var testValidator = new TestValidator<CommandA>();
            var self = new CommandAndValidatorType(command, typeof(TestValidator<CommandA>));
            var result = CommandValidationSteps.CreateValidator(
                self,
                t =>
                {
                    t.ShouldBe(typeof(TestValidator<CommandA>));
                    return testValidator;
                });
            result.Command.ShouldBe(command);
            result.Validator.ShouldBe(testValidator);
        }

        [Test]
        public void TestCommandNullOut()
        {
            var command = new CommandA();
            var self = new CommandAndValidatorType(command, typeof(TestValidator<CommandA>));
            var result = CommandValidationSteps.CreateValidator(
                self,
                t =>
                {
                    t.ShouldBe(typeof(TestValidator<CommandA>));
                    return null;
                });
            result.Command.ShouldBe(command);
            result.Validator.ShouldBe(null);
        }

        [Test]
        public void TestCommandNullIn()
        {
            var command = new CommandA();
            var self = new CommandAndValidatorType(command, null);
            var spy = Substitute.For<Func<Type, IValidator>>();
            var result = CommandValidationSteps.CreateValidator(self, spy);
            result.Command.ShouldBe(command);
            result.Validator.ShouldBe(null);
            spy.DidNotReceive().Invoke(Arg.Any<Type>());
        }

        [Test]
        public void TestQuery()
        {
            var query = new QueryA();
            var testValidator = new TestValidator<QueryA>();
            var self = new QueryAndValidatorType(query, typeof(TestValidator<QueryA>));
            var result = QueryValidationSteps.CreateValidator(
                self,
                t =>
                {
                    t.ShouldBe(typeof(TestValidator<QueryA>));
                    return testValidator;
                });
            result.Query.ShouldBe(query);
            result.Validator.ShouldBe(testValidator);
        }

        [Test]
        public void TestQueryNullOut()
        {
            var query = new QueryA();
            var self = new QueryAndValidatorType(query, typeof(TestValidator<QueryA>));
            var result = QueryValidationSteps.CreateValidator(
                self,
                t =>
                {
                    t.ShouldBe(typeof(TestValidator<QueryA>));
                    return null;
                });
            result.Query.ShouldBe(query);
            result.Validator.ShouldBe(null);
        }

        [Test]
        public void TestQueryNullIn()
        {
            var query = new QueryA();
            var self = new QueryAndValidatorType(query, null);
            var spy = Substitute.For<Func<Type, IValidator>>();
            var result = QueryValidationSteps.CreateValidator(self, spy);
            result.Query.ShouldBe(query);
            result.Validator.ShouldBe(null);
            spy.DidNotReceive().Invoke(Arg.Any<Type>());
        }

        [Test]
        public void TestConstraintNullIn()
        {
            var self = new ValidatorType(null);
            var spy = Substitute.For<Func<Type, IValidator>>();
            var result = FluentConstraintsSteps.CreateValidator(self, spy);
            result.ShouldBe(null);
            spy.DidNotReceive().Invoke(Arg.Any<Type>());
        }
    }
}