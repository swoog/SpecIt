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
    }
}
