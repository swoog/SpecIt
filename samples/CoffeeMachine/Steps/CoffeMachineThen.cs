namespace CoffeeMachine.Steps
{
    using SpecIt;
    using SpecIt.Assert;

    public static class CoffeMachineThen
    {
        public static IThenOperator<IThen> the_message_expectedMessage_is_shown(this IThen then, string message)
        {
            return then.Assert<CoffeeMachine, string>(c => c.Message).IsEqualTo(message);
        }

        public static IThenOperator<IThen> an_error_should_be_shown(this IThen then)
        {
            return then.Assert<CoffeeMachine, string>(c => c.Message).StartsWith("Error");
        }

        public static IThenOperator<IThen> no_error_is_shown(this IThen then)
        {
            return then.Assert<CoffeeMachine, string>(c => c.Message).NotStartsWith("Error");
        }

        public static IThenOperator<IThen> no_coffee_should_be_served(this IThen then)
        {
            return then.Assert<CoffeeMachine, int>(c => c.Coffees).Is(v => true);
        }

        public static IThenOperator<IThen> I_should_be_served_a_coffee(this IThen then)
        {
            return then.I_shouldOrNot_be_served_a_coffee(true);
        }
        public static IThenOperator<IThen> I_should_not_be_served_a_coffee(this IThen then)
        {
            return then.I_shouldOrNot_be_served_a_coffee(false);
        }

        public static IThenOperator<IThen> I_shouldOrNot_be_served_a_coffee(this IThen then, bool b)
        {
            if (!b)
            {
                return then.Assert<int>().IsEqualTo(0);
            }

            return then.Assert<int>().IsNotEqualTo(0);
        }
        public static IThenOperator<IThen> a_coffee_should_be_served(this IThen then)
        {
            return then.I_should_be_served_a_coffee();
        }

        public static IThenOperator<IThen> there_are_numberOfCoffee_coffees_left_in_the_machine(this IThen then, int numberOfCoffee)
        {
            return then.Assert<CoffeeMachine, int>(c => c.Coffees).IsEqualTo(numberOfCoffee);
        }


    }
}