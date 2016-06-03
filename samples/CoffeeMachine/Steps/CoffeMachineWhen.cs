namespace CoffeeMachine.Steps
{
    using SpecIt;

    public static class CoffeMachineWhen
    {
        public static IWhenOperator I_insert_euros_one_euro_coins(this IWhen when, int euros)
        {
            return when.Action<CoffeeMachine>(
                c =>
                    {
                        c.InsertOneEuroCoin(euros);
                    });
        }

        public static IWhenOperator I_press_the_coffee_button(this IWhen when)
        {
            return when.Func<CoffeeMachine, int>(c => c.PressButton());
        }
    }
}