using System.Collections.Generic;

namespace PizzaApi
{
    public class Menu
    {

        public List<Pizza> Pizzas { get; set; }
        public List<Drink> Drinks { get; set; }
        public List<Ingredient> ExtraIngredients { get; set; }

    }
}
