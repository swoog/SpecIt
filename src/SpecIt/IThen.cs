namespace SpecIt
{
    using System;

    public interface IThen
    {
        IAssert<TResult> Assert<T, TResult>(Func<T, TResult> func);
    }
}