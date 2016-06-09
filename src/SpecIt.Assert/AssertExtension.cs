using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecIt.Assert
{
    using System.Runtime.CompilerServices;

    using SpecIt.Assertion;

    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class AssertExtension
    {
        public static IAssert<TResult> Assert<T, TResult>(this IThen then, Func<T, TResult> func)
        {
            var data = Scenario.Resolver.Resolve<T>();
            var value = func(data);


            return Scenario.Resolver.Resolve<Assert<TResult>>(new { value = value });
        }
    }
}
