namespace SpecIt
{
    using System;
    using System.Collections.Generic;

    public interface IWhen
    {
        IWhenOperator Action<T>(Action<T> action);

        IWhenOperator Func<T, TResult>(Func<T, TResult> action);

        TResult Get<T, TResult>(Func<T, TResult> func);

        T GetReturnValue<T>();
    }
}