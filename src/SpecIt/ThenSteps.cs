namespace SpecIt
{
    using System;

    public class ThenSteps<T> : ThenSteps
    where T : IThen
    {
        public ThenSteps(Scenario scenario)
            : base(scenario)
        {
        }
    }

    public class ThenSteps : IThen
    {
        public ThenSteps(Scenario scenario)
        {
            this.Scenario = scenario;
        }

        public Scenario Scenario { get; }

        public T GetReturnValue<T>()
        {
            return (T)this.Scenario.ReturnValue;
        }

        public bool ReturnValueIs<T>()
        {
            return this.Scenario.ReturnValue is T;
        }

        public IThenOperator<T> Next<T>() where T : IThen
        {
            return this.Scenario.Resolver.Resolve<ThenOperator<T>>();
        }

        public IThenOperator<IThen> Next()
        {
            return this.Scenario.Resolver.Resolve<ThenOperator<IThen>>(new { Then = this });
        }
    }
}