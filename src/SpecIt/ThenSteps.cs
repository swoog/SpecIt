namespace SpecIt
{
    using System;

    public class ThenSteps : IThen
    {
        private readonly ThenOperator thenOperator;

        private readonly IResolver resolver;

        public ThenSteps(IResolver resolver)
        {
            this.thenOperator = new ThenOperator(this);
            this.resolver = resolver;
        }

        public IAssert<TResult> Assert<T, TResult>(Func<T, TResult> func)
        {
            return new Assert<TResult>(func(this.resolver.Resolve<T>()), this.thenOperator);
        }
    }
}