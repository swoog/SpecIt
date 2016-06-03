namespace SpecIt
{
    public class WhenOperator : IWhenOperator
    {
        private readonly WhenSteps whenSteps;

        private readonly IResolver resolver;

        public WhenOperator(WhenSteps whenSteps, IResolver resolver)
        {
            this.whenSteps = whenSteps;
            this.resolver = resolver;
        }

        public IWhen And()
        {
            return this.whenSteps;
        }

        public IThen Then()
        {
            return new ThenSteps(this.resolver);
        }
    }
}