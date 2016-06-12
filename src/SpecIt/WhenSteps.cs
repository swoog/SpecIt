namespace SpecIt
{
    using System;

    public class WhenSteps : IWhen
    {
        private readonly IResolver resolver;

        public WhenSteps(IResolver resolver, Scenario scenario)
        {
            this.resolver = resolver;
            this.Scenario = scenario;
        }

        public IWhenOperator Action<T>(Action<T> action)
        {
            action(this.resolver.Resolve<T>());
            return new WhenOperator(this, this.Scenario);
        }

        public Scenario Scenario { get; }

        public IWhenOperator Func<T, TResult>(Func<T, TResult> action)
        {
            this.Scenario.ReturnValue = action(this.resolver.Resolve<T>());
            return new WhenOperator(this, this.Scenario);
        }
    }
}