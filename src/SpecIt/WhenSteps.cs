namespace SpecIt
{
    using System;

    public class WhenSteps : IWhen
    {
        private readonly IResolver resolver;

        public WhenSteps(IResolver resolver)
        {
            this.resolver = resolver;
        }

        public IWhenOperator Action<T>(Action<T> action)
        {
            action(this.resolver.Resolve<T>());
            return new WhenOperator(this, this.resolver);
        }

        public IWhenOperator Func<T, TResult>(Func<T, TResult> action)
        {
            action(this.resolver.Resolve<T>());
            return new WhenOperator(this, this.resolver);
        }
    }
}