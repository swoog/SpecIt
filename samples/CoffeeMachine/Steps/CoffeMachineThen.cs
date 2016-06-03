﻿namespace CoffeeMachine.Steps
{
    using SpecIt;

    public static class CoffeMachineThen
    {
        public static IThenOperator the_message_expectedMessage_is_shown(this IThen then, string message)
        {
            return then.Assert<CoffeeMachine, string>(c => c.Message).IsEqualTo(message);
        }

        public static IThenOperator an_error_should_be_shown(this IThen then)
        {
            return then.Assert<CoffeeMachine, string>(c => c.Message).StartsWith("Error");
        }

        public static IThenOperator no_coffee_should_be_served(this IThen then)
        {
            return then.Assert<CoffeeMachine, int>(c => c.Coffees).Is(v => true);
        }

        public static IThenOperator I_should_be_served_a_coffee(this IThen then, bool b)
        {
            return then.Assert<CoffeeMachine, bool>(c => true).IsEqualTo(b);
        }

        public static IThenOperator a_coffee_should_be_served(this IThen then)
        {
            return then.I_should_be_served_a_coffee(true);
        }

        public static IThenOperator there_are_numberOfCoffee_coffees_left_in_the_machine(this IThen then, int numberOfCoffee)
        {
            return then.Assert<CoffeeMachine, int>(c => c.Coffees).IsEqualTo(numberOfCoffee);
        }


    }
}