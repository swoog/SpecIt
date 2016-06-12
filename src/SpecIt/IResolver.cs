namespace SpecIt
{
    public interface IResolver
    {
        T Resolve<T>();

        T Resolve<T>(object constructorArguments);

        void BindTo<T>(T obj);
    }
}