using SpecIt.Assertion;

namespace SpecIt
{
    public interface IResolver
    {
        T Resolve<T>();

        T Resolve<T>(object constructorArguments);
    }
}