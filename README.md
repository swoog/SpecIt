# SpecIt

SpecIt is a library to create unit test code with a Gherkin language.

        [Fact]
        public void an_empty_coffee_machine()
        {
            this
                .Given().a_coffee_machine()

                .And().there_are_no_more_coffees_left()

                .Then().there_are_numberOfCoffee_coffees_left_in_the_machine(0);
        }
