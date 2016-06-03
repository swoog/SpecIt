namespace CoffeeMachine
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class CoffeeMachine
    {
        private readonly List<Coin> coins = new List<Coin>();

        public int Coffees { get; set; }

        public string Message { get; set; }

        public bool On { get; set; }

        public void InsertOneEuroCoin(int euros)
        {
            this.coins.Add(new Coin(euros));
        }

        public int PressButton()
        {
            if (this.Coffees == 0)
            {
                this.Message = "Error: No coffees left";
                return 0;
            }

            if (this.coins.Sum(c => c.Euros) < 2)
            {
                this.Message = "Error: Insufficient money";
                return 0;
            }


            this.Message = "Enjoy your coffee!";
            this.Coffees--;
            return 0;
        }
    }

    public class Coin
    {
        public int Euros { get; }

        public Coin(int euros)
        {
            this.Euros = euros;
        }
    }
}