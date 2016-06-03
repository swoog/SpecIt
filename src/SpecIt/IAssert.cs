namespace SpecIt
{
    using System;

    public interface IAssert<T>
    {
        IThenOperator Is(Func<T, bool> predicate);

        IThenOperator IsEqualTo(T expected);

        IThenOperator StartsWith(string message);
    }
}