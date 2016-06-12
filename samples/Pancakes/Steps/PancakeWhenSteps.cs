namespace Pancakes.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SpecIt;

    public static class PancakeWhenSteps
    {
        public static IWhenOperator the_cook_mangles_everthing_to_a_dough(this IWhen when)
        {
            var ingredients = when.Get<IngredientsContext, List<string>>(i => i.Ingredients);

            return when.Func<Cook, HashSet<string>>(cook => cook.MakeADough(ingredients));
        }

        public static IWhenOperator the_cook_fries_the_dough_in_a_pan(this IWhen when)
        {
            var dough = when.GetReturnValue<HashSet<string>>();

            return
                when.Func<Cook, string>(
                    cook => cook.FryDoughInAPan(dough));
        }
    }

    public class Cook
    {
        public HashSet<string> MakeADough(List<string> ingredients)
        {
            return new HashSet<string>(ingredients);
        }

        public string FryDoughInAPan(HashSet<string> dough)
        {
            if (dough.Contains("egg") && dough.Contains("milk") && dough.Contains("flour"))
            {
                return "pancake";
            }

            return "mishmash";
        }
    }
}