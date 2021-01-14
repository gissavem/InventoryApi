using System.Collections.Generic;

namespace PizzaApi
{
    public class DrinkBL
    {
        private const int Price20 = 20;
        private const int Price25 = 25;

        public Drink CreateDrink(int drinkId)
        {
            return drinkId switch
            {
                (int) Drinks.Coke => new Drink(Drinks.Coke.ToString(), Price20),
                (int) Drinks.Fanta => new Drink(Drinks.Fanta.ToString(), Price20),
                (int) Drinks.Sprite => new Drink(Drinks.Sprite.ToString(), Price25),
                _ => throw new ItemNotFoundException(drinkId.ToString())
            };
        }
    }
}
