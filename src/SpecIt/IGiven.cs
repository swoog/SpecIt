namespace SpecIt
{
    using System;

    public interface IGiven
    {
        IGivenOperator<T> Next<T>() where T : IGiven;

        IGivenOperator<IGiven> Next();

        IGiven Set<T>(Action<T> func);
    }
}