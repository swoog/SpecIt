namespace SpecIt
{
    using System;

    public class GivenOperator<T> : IGivenOperator<T>
        where T : IGiven
    {
        private readonly T given;

        private readonly IResolver resolver;

        public GivenOperator(T given, IResolver resolver, Scenario scenario)
        {
            this.given = given;
            this.resolver = resolver;
            this.Scenario = scenario;
        }

        public T And()
        {
            return this.given;
        }

        public IWhen When()
        {
            return new WhenSteps(this.resolver, this.Scenario);
        }

        public Scenario Scenario { get; }

        public IThen Then()
        {
            return new ThenSteps(this.Scenario);
        }
    }
}