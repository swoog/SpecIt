namespace SpecIt
{
    using System;

    public interface IWhen
    {
        IWhenOperator Action<T>(Action<T> action);

        IWhenOperator Func<T, TResult>(Func<T, TResult> action);
    }
}