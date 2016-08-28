namespace SpecIt
{
    using System;

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

        public IGivenOperator<IGiven> Next()
        {
            return this.resolver.Resolve<GivenOperator<IGiven>>(new { Given = this });
        }

        public IGiven Set<T>(Action<T> func)
        {
            func(this.resolver.Resolve<T>());
            return this;
        }

        public IGiven Set<T>(Func<T> func)
        {
            this.resolver.BindTo(func());
            return this;
        }
    }
}