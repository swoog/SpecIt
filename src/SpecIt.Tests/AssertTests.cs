using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecIt.Tests
{
    using NFluent;

    using NSubstitute;

    using SpecIt.Assert;

    using Xunit;

    public class AssertTests
    {
        private readonly IThen then;

        private readonly MyObject myObject;

        public AssertTests()
        {
            var scenario = new Scenario();
            this.myObject = new MyObject("Fake value to simulate a constructor argument");
            scenario.ReturnValue = this.myObject;

            this.then = new ThenSteps(scenario);
        }

        [Fact]
        public void Should_execute_action_When_assert()
        {
            Check.ThatCode(() => this.then.Assert<MyObject>(v => { throw  new Exception("Error");}))
                .Throws<Exception>()
                .WithMessage("Error");
        }

        [Fact]
        public void Should_throw_exception_When_no_property_name()
        {
            var assertion = this.then.Assert<MyObject, int>(v => 1);

            Check.ThatCode(() => assertion.IsEqualTo(2))
                .Throws<SpecItException>()
                .WithMessage("Expected the int value 2 but was 1");
        }

        [Fact]
        public void Should_throw_exception_When_int_are_note_equal()
        {
            this.myObject.ItemsOrder = 1;
            var assertion = this.then.Assert<MyObject, int>(v => v.ItemsOrder);

            Check.ThatCode(() => assertion.IsEqualTo(2))
                .Throws<SpecItException>()
                .WithMessage("Items order expected the int value 2 but was 1");
        }

        [Fact]
        public void Should_throw_exception_When_string_are_note_equal()
        {
            this.myObject.Name = "Aurelien";
            var assertion = this.then.Assert<MyObject, string>(v => v.Name);

            Check.ThatCode(() => assertion.IsEqualTo("Aurélien"))
                .Throws<SpecItException>()
                .WithMessage("Name expected the string value \"Aurélien\" but was \"Aurelien\"");
        }
    }

    public class MyObject
    {
        public MyObject(string c)
        {

        }

        public string Name { get; set; }

        public int ItemsOrder { get; set; }
    }
}
