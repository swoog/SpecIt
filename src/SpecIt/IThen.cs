namespace SpecIt
{
    using System;

    using SpecIt.Assertion;

    public interface IThen
    {
        IAssert<TResult> Assert<T, TResult>(Func<T, TResult> func);
    }
}