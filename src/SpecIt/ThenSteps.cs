namespace SpecIt
{
    using System;

    using SpecIt.Assertion;

    public class ThenSteps : IThen
    {
        private readonly ThenOperator thenOperator;

        private readonly IResolver resolver;

        public ThenSteps(IResolver resolver)
        {
            this.thenOperator = new ThenOperator(this);
            this.resolver = resolver;
        }
    }
}