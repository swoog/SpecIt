namespace SpecIt
{
    using System;

    public class GivenOperator<T> : IGivenOperator<T>
        where T : IGiven
    {
        private readonly T given;

        private readonly IResolver resolver;

        public GivenOperator(T given, IResolver resolver)
        {
            this.given = given;
            this.resolver = resolver;
        }

        public T And()
        {
            return this.given;
        }

        public IWhen When()
        {
            return new WhenSteps(this.resolver);
        }

        public IThen Then()
        {
            return new ThenSteps(this.resolver);
        }
    }
}