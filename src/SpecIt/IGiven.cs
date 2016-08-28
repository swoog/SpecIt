namespace SpecIt
{
    using System;

    public interface IGiven
    {
        IGivenOperator<T> Next<T>() where T : IGiven;

        IGivenOperator<IGiven> Next();

        IGivenOperator<IGiven> Set<T>(Action<T> func);

        IGivenOperator<IGiven> Set<T>(Func<T> func);
    }
}