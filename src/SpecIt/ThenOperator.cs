namespace SpecIt
{
    public class ThenOperator : IThenOperator
    {
        private readonly ThenSteps thenSteps;

        public ThenOperator(ThenSteps thenSteps)
        {
            this.thenSteps = thenSteps;
        }

        public IThen And()
        {
            return this.thenSteps;
        }
    }
}