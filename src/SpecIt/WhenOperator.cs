namespace SpecIt
{
    public class WhenOperator : IWhenOperator
    {
        private readonly WhenSteps whenSteps;

        public WhenOperator(WhenSteps whenSteps, Scenario scenario)
        {
            this.whenSteps = whenSteps;
            this.Scenario = scenario;
        }

        public IWhen And()
        {
            return this.whenSteps;
        }

        public IThen Then()
        {
            return new ThenSteps(this.Scenario);
        }

        public Scenario Scenario { get; }
    }
}