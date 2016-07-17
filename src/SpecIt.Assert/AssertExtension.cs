namespace SpecIt.Assert
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public static class AssertExtension
    {
        public static IAssert<TResult> Assert<TResult>(this IThen then)
        {
            var value = then.GetReturnValue<TResult>();
            return then.Scenario.Resolver.Resolve<Assert<TResult>>(new { value = value, propertyName = (string)null });
        }

        public static void Assert<T>(this IThen then, Action<T> func)
        {
            T data;
            if (then.ReturnValueIs<T>())
            {
                data = then.GetReturnValue<T>();
            }
            else
            {
                data = then.Scenario.Resolver.Resolve<T>();
            }

            func(data);
        }

        public static IAssert<TResult> Assert<T, TResult>(this IThen then, Expression<Func<T, TResult>> func)
        {
            T data;
            if (then.ReturnValueIs<T>())
            {
                data = then.GetReturnValue<T>();
            }
            else
            {
                data = then.Scenario.Resolver.Resolve<T>();
            }

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
