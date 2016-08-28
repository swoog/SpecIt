namespace SpecIt.Assert
{
    using System;

    public interface IAssert<T>
    {
        IThenOperator<IThen> Is(Func<T, bool> predicate);

        IThenOperator<IThen> IsEqualTo(T expected);

        IThenOperator<IThen> StartsWith(string message);

        IThenOperator<IThen> IsNotEqualTo(T expected);

        IThenOperator<IThen> NotStartsWith(string message);

        IThenOperator<TThenStep> HasSingle<TChild, TThenStep>() where TThenStep : IThen;

        IThenOperator<TThenStep> Has<TChild, TThenStep>(int numberElement) where TThenStep : IThen;
    }
}