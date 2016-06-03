namespace SpecIt
{
    public class GivenSteps<T> : GivenSteps
        where T : IGiven
    {
        public GivenSteps(IResolver resolver)
            : base(resolver)
        {
        }

        public IGivenOperator<T> Next()
        {
            return new GivenOperator<T>(this.resolver.Resolve<T>(), this.resolver);
        }
    }

    public class GivenSteps : IGiven
    {
        protected readonly IResolver resolver;

        public GivenSteps(IResolver resolver)
        {
            this.resolver = resolver;
        }

        public IGivenOperator<T> Next<T>()
            where T : IGiven
        {
            return new GivenOperator<T>(this.resolver.Resolve<T>(), this.resolver);
        }
    }
}