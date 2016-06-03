namespace SpecIt
{
    public interface IGivenOperator<T>
        where T : IGiven
    {
        T And();

        IWhen When();

        IThen Then();
    }
}