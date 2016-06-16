namespace SpecIt.Tests
{
    using SpecIt;

    using NFluent;

    using Xunit;

    public class StepsTests
    {
        [Fact]
        public void Should_display_error_message_When_resolver_does_not_contains_binding()
        {
            var resolver = new Resolver();

            Check.ThatCode(() => resolver.Resolve<IFakeInterface>())
                .Throws<ResolverException>()
                .WithMessage("IFakeInterface has no binding");
        }
    }

    public interface IFakeInterface
    {
    }
}
