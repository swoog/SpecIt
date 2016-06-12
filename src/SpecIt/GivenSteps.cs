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
            return this.resolver.Resolve<GivenOperator<T>>();
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
            return this.resolver.Resolve<GivenOperator<T>>();
        }
    }
}