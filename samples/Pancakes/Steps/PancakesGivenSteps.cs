using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pancakes.Steps
{
    using SpecIt;

    public static class PancakesGivenSteps
    {
        public static IGivenOperator<IGiven> an_egg(this IGiven given)
        {
            return given.the_ingredient("egg");
        }

        public static IGivenOperator<IGiven> the_ingredient(this IGiven given, string ingredient)
        {
            return given.Set<IngredientsContext>(m => m.Ingredients.Add(ingredient));
        }

        public static IGivenOperator<IGiven> some_milk(this IGiven given)
        {
            return given.the_ingredient("milk");
        }
    }

    public class IngredientsContext
    {
        public List<string> Ingredients { get; } = new List<string>();
    }
}
