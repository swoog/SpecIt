namespace SpecIt.Pattern
{
    public class ScenarioPattern : Scenario
    {
        public ScenarioPattern()
            : base(new PatternResolver())
        {
        }
    }
}
