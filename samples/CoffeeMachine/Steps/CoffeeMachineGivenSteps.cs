namespace CoffeeMachine.Steps
{
    using SpecIt;

    public class CoffeeMachineGivenSteps : GivenSteps<CoffeeMachineGivenSteps>
    {
        private readonly CoffeeMachine coffeeMachine;

        public CoffeeMachineGivenSteps(CoffeeMachine coffeeMachine, IResolver resolver)
            : base(resolver)
        {
            this.coffeeMachine = coffeeMachine;
        }

        public IGivenOperator<CoffeeMachineGivenSteps> there_are_no_more_coffees_left()
        {
            return this.there_are_numberCoffee_coffees_left_in_the_machine(0);
        }

        public IGivenOperator<CoffeeMachineGivenSteps> there_are_numberCoffee_coffees_left_in_the_machine(int numberCoffee)
        {
            this.coffeeMachine.Coffees = numberCoffee;
            return this.Next();
        }

        public IGivenOperator<CoffeeMachineGivenSteps> the_machine_is_turned_off()
        {
            this.coffeeMachine.On = false;
            return this.Next();
        }

        public IGivenOperator<CoffeeMachineGivenSteps> the_machine_is_onOrOff(bool onOrOff)
        {
            this.coffeeMachine.On = onOrOff;
            return this.Next();
        }

        public IGivenOperator<CoffeeMachineGivenSteps> the_coffee_costs_money_dollar(int money)
        {
            this.coffeeMachine.Cost = money;
            return this.Next();
        }
    }
}