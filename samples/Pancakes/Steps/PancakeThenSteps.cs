namespace Pancakes.Steps
{
    using System;
    using System.Collections.Generic;

    using SpecIt;
    using SpecIt.Assert;

    public static class PancakeThenSteps
    {
        public static IThenOperator the_resulting_meal_is_a_pan_cake(this IThen then)
        {
            return then.Assert<string>().IsEqualTo("pancake");
        }
    }
}