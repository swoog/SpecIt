namespace SpecIt.Pattern
{
    using global::Pattern.Core;
    using global::Pattern.Core.Interfaces;
    using global::Pattern.Core.Interfaces.Factories;

    public class PatternResolver : IResolver
    {
        private readonly IKernel kernel = new Kernel();

        public T Resolve<T>()
        {
            return (T)this.kernel.Get(typeof(T));
        }

        public T Resolve<T>(object constructorArguments)
        {
            return (T)this.kernel.Get(typeof(T));
        }

        public void BindTo<T>(T obj)
        {
            this.kernel.Bind(typeof(T), new LambdaFactory(() => obj));
        }
    }
}