namespace SpecIt
{
    using System;

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
    }
}