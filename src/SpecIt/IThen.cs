namespace SpecIt
{
    public interface IThen
    {
        Scenario Scenario { get; }

        T GetReturnValue<T>();

        bool ReturnValueIs<T>();
    }
}