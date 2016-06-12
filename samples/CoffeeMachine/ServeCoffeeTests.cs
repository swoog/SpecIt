
namespace CoffeeMachine
{
    using System;

    using global::CoffeeMachine.Steps;

    using SpecIt;

    using Xunit;

    public class ServeCoffeeTests : Scenario
    {
        [Fact]
        public void an_empty_coffee_machine()
        {
            this
                .Given().a_coffee_machine()

                .And().there_are_no_more_coffees_left()

                .Then().there_are_numberOfCoffee_coffees_left_in_the_machine(0);
        }

        [Fact]
        public void an_empty_coffee_machine_cannot_serve_any_coffee()
        {
            this
                .Given().an_empty_coffee_machine()

                .When().I_insert_euros_one_euro_coins(5)
                .And().I_press_the_coffee_button()

                .Then().an_error_should_be_shown()
                .And().no_coffee_should_be_served();
        }

        [Fact]
        public void no_coffee_left_error_is_shown_when_there_is_no_coffee_left()
        {
            this
                .Given().an_empty_coffee_machine()

                .When().I_insert_euros_one_euro_coins(5)
                .And().I_press_the_coffee_button()

                .Then().the_message_expectedMessage_is_shown("Error: No coffees left");
        }

        [Fact]
        public void not_enough_money_message_is_shown_when_insufficient_money_was_given()
        {
            this
                .Given().a_coffee_machine()
                .And().there_are_numberCoffee_coffees_left_in_the_machine(2)

                .When().I_insert_euros_one_euro_coins(1)

                .And().I_press_the_coffee_button()
                .Then().the_message_expectedMessage_is_shown("Error: Insufficient money");
        }

        [Theory]
        [InlineData(0, 0, "Error: No coffees left")]
        [InlineData(0, 1, "Error: No coffees left")]
        [InlineData(1, 0, "Error: Insufficient money")]
        [InlineData(0, 5, "Error: No coffees left")]
        [InlineData(1, 5, "Enjoy your coffee!")]
        public void correct_messages_are_shown(int coffeesLeft, int numberOfCoins, string message)
        {
            this
                .Given().a_coffee_machine()
                .And().there_are_numberCoffee_coffees_left_in_the_machine(coffeesLeft)

                .When().I_insert_euros_one_euro_coins(numberOfCoins)
                .And().I_press_the_coffee_button()

                .Then().the_message_expectedMessage_is_shown(message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(10)]
        public void serving_a_coffee_reduces_the_number_of_available_coffees_by_one(int initialCoffees)
        {
            this
                .Given().a_coffee_machine()
                .And().there_are_numberCoffee_coffees_left_in_the_machine(initialCoffees)

                .When().I_insert_euros_one_euro_coins(2)
                .And().I_press_the_coffee_button()

                .Then().a_coffee_should_be_served()
                .And().there_are_numberOfCoffee_coffees_left_in_the_machine(initialCoffees - 1);
        }

        [Fact]
        public void a_turned_off_coffee_machine_cannot_serve_coffee()
        {
            this
                .Given().a_coffee_machine()
                .And().the_machine_is_turned_off()
                .When().I_press_the_coffee_button()
                .Then().no_coffee_should_be_served();
        }

        [Theory]
        [InlineData(true, 1, 1, false)]
        [InlineData(true, 1, 2, true)]
        [InlineData(true, 0, 2, false)]
        [InlineData(false, 1, 2, false)]
        public void buy_a_coffee(bool onOrOff, int coffees, int dollars, bool shouldOrShouldNot)
        {
            this.
                Given().a_coffee_machine().
                And().there_are_numberCoffee_coffees_left_in_the_machine(coffees).
                And().the_machine_is_onOrOff(onOrOff).
                And().the_coffee_costs_money_dollar(2)

                .When().I_insert_euros_one_euro_coins(dollars)
                .And().I_press_the_coffee_button()

                .Then().I_shouldOrNot_be_served_a_coffee(shouldOrShouldNot);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void turned_off_machines_should_not_serve_coffee(bool onOrOff)
        {
            var when =
                this
                .Given().a_coffee_machine()
                .And().there_are_numberCoffee_coffees_left_in_the_machine(2)
                .And().the_machine_is_onOrOff(onOrOff)

                .When().I_insert_euros_one_euro_coins(2)
                .And().I_press_the_coffee_button();

            if (onOrOff)
            {
                when.Then().I_should_be_served_a_coffee();
            }
            else
            {
                when.Then().I_should_not_be_served_a_coffee().
                    And().no_error_is_shown();
            }
        }
    }
}
