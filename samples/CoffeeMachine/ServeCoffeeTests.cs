
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

        //    @TagsWithCustomStyle
        //    @Test
        //@DataProvider( {
        //        "true, 1, 1, false",
        //    "true, 1, 2, true",
        //    "true, 0, 2, false",
        //    "false, 1, 2, false",
        //} )
        //public void buy_a_coffee(boolean onOrOff, int coffees, int dollars, boolean shouldOrShouldNot)
        //    {

        //        given().a_coffee_machine().
        //            and().there_are_$_coffees_left_in_the_machine(coffees).
        //            and().the_machine_is_$onOrOff(onOrOff).
        //            and().the_coffee_costs_$_dollar(2);

        //        when().I_insert_$_one_euro_coins(dollars).
        //            and().I_press_the_coffee_button();

        //        then().I_$shouldOrShouldNot_be_served_a_coffee(shouldOrShouldNot);
        //    }

        //    @Test
        //    @FeatureCaseDiffs
        //@DataProvider( { "true", "false" } )
        //public void turned_off_machines_should_not_serve_coffee(boolean onOrOff)
        //    {
        //        given().a_coffee_machine()
        //            .and().there_are_$_coffees_left_in_the_machine(2)
        //            .and().the_machine_is_$onOrOff(onOrOff);

        //        when().I_insert_$_one_euro_coins(2).
        //            and().I_press_the_coffee_button();

        //        if (onOrOff)
        //        {
        //            then().I_should_be_served_a_coffee();
        //        }
        //        else
        //        {
        //            then().I_should_not_be_served_a_coffee().
        //                and().no_error_is_shown();
        //        }

        //    }

        //    @Test
        //public void a_failing_scenario_for_demonstration_purposes()
        //    {
        //        given().a_coffee_machine()
        //            .and().there_are_no_more_coffees_left();
        //        when().I_press_the_coffee_button();
        //        then().I_should_be_served_a_coffee()
        //            .and().steps_following_a_failed_step_should_be_skipped();
        //    }

        //    @Test
        //    @DataProvider( {
        //        "true",
        //    "false"
        //    } )
        //public void a_scenario_with_a_failing_test_case_for_demonstration_purposes(boolean withCoffees)
        //    {
        //        given().a_coffee_machine();

        //        if (withCoffees)
        //        {
        //            given().and().there_are_$_coffees_left_in_the_machine(2);
        //        }

        //        when().I_insert_$_one_euro_coins(2).
        //            and().I_press_the_coffee_button();

        //        then().I_should_be_served_a_coffee();
        //    }

        //    @Test
        //public void intro_words_are_not_required()
        //    {
        //        given().a_coffee_machine()
        //            .the_coffee_costs_$_dollar(5)
        //            .there_are_$_coffees_left_in_the_machine(3);

        //        when().I_press_the_coffee_button();

        //        then().an_error_should_be_shown()
        //            .no_coffee_should_be_served();
        //    }

        //@Test(timeout = 1000)
        //public void shouldFailWithUnexpectedRuntimeException() throws Exception
        //    {
        //        then().$( "should throw a runtime exception", //$NON-NLS-1$
        //        new StepFunction<ThenCoffee>() {
        //            @Override
        //            public void apply(final ThenCoffee stage )
        //                    throws Exception
        //    {
        //        Thread.sleep( 2000 );
        //    }
        //} );
        //}

    }
}
