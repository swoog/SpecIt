using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecIt.Assert
{
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class AssertExtension
    {
        public static IAssert<TResult> Assert<TResult>(this IThen then)
        {
            var value = then.GetReturnValue<TResult>();
            return then.Scenario.Resolver.Resolve<Assert<TResult>>(new { value = value, propertyName = (string)null });
        }

        public static IAssert<TResult> Assert<T, TResult>(this IThen then, Expression<Func<T, TResult>> func)
        {
            var data = then.Scenario.Resolver.Resolve<T>();
            var propertyName = GetPropertyName(func);
            var value = func.Compile()(data);

            return then.Scenario.Resolver.Resolve<Assert<TResult>>(new { value = value, propertyName = propertyName });
        }

        private static string GetPropertyName<T, TResult>(Expression<Func<T, TResult>> func)
        {
            var body = func.Body as MemberExpression;

            return body?.Member.Name;
        }
    }
}
