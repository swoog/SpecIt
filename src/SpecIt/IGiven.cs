namespace SpecIt
{
    public interface IGiven
    {
        IGivenOperator<T> Next<T>() where T : IGiven;
    }
}