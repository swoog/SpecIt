namespace SpecIt.Assert
{
    using System;
    using System.Linq.Expressions;

    public static class AssertExtension
    {
        public static IAssert<TResult> Assert<TResult>(this IThen then)
        {
            var value = then.GetReturnValue<TResult>();
            return then.Scenario.Resolver.Resolve<Assert<TResult>>(new { value = value, propertyName = (string)null });
        }

        public static IAssert<TResult> Assert<T, TResult>(this IThen then, Expression<Func<T, TResult>> func)
        {
            var data = then.GetReturnValue<T>();
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
