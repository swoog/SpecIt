using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pancakes
{
    using Pancakes.Steps;

    using SpecIt;

    using Xunit;

    public class PancakesTests : Scenario
    {
        [Fact]
        public void a_meal_can_be_fried_out_of_an_egg_milk_and_some_ingredient()
        {
            this
            .Given().an_egg()
            .And().some_milk()
            .And().the_ingredient("flour")

            .When().the_cook_mangles_everthing_to_a_dough()
            .And().the_cook_fries_the_dough_in_a_pan()

            .Then().the_resulting_meal_is_a_pan_cake();

        }
    }
}
