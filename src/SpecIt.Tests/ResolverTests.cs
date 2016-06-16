using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecIt.Tests
{
    using NFluent;

    using Xunit;

    public class ResolverTests
    {

        [Fact]
        public void Should_resolver_is_not_the_same_When_instanciate_new_scenario()
        {
            var scenario1 = new Scenario();
            var scenario2 = new Scenario();

            Check.That(scenario1.Resolver).IsNotEqualTo(scenario2.Resolver);
        }

        [Fact]
        public void Should_display_error_message_When_resolver_does_not_contains_binding()
        {
            var resolver = new Resolver();

            Check.ThatCode(() => resolver.Resolve<IFakeInterface>())
                .Throws<ResolverException>()
                .WithMessage("IFakeInterface has no binding");
        }

        [Fact]
        public void Should_display_error_message_When_resolve_type_with_no_constructor()
        {
            var resolver = new Resolver();

            Check.ThatCode(() => resolver.Resolve<char>())
                .Throws<ResolverException>()
                .WithMessage("Char has no constructor");
        }

        [Fact]
        public void Should_display_stack_message_When_resolve_type_with_no_constructor()
        {
            var resolver = new Resolver();

            Check.ThatCode(() => resolver.Resolve<FakeObjectWithCharConstructor>())
                .Throws<ResolverException>()
                .WithMessage("Char has no constructor when resolver injection to :\nFakeObjectWithCharConstructor");
        }

        [Fact]
        public void Should_display_stack_message_When_resolve_type_with_no_constructor_and_parent()
        {
            var resolver = new Resolver();

            Check.ThatCode(() => resolver.Resolve<FakeParentObjectWithCharConstructor>())
                .Throws<ResolverException>()
                .WithMessage("Char has no constructor when resolver injection to :\nFakeObjectWithCharConstructor\nFakeParentObjectWithCharConstructor");
        }
    }
}
