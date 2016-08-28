namespace SpecIt
{
    public interface IThen
    {
        Scenario Scenario { get; }

        T GetReturnValue<T>();

        bool ReturnValueIs<T>();

        IThenOperator<T> Next<T>() where T : IThen;

        IThenOperator<IThen> Next();
    }
}