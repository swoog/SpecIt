namespace CoffeeMachine.Steps
{
    using SpecIt;

    public static class CoffeMachineGiven
    {
        public static IGivenOperator<CoffeeMachineGivenSteps> a_coffee_machine(this IGiven given)
        {
            return given.Next<CoffeeMachineGivenSteps>();
        }


        public static IGivenOperator<CoffeeMachineGivenSteps> an_empty_coffee_machine(this IGiven given)
        {
            return given.a_coffee_machine()
                .And().there_are_no_more_coffees_left();
        }
    }
}