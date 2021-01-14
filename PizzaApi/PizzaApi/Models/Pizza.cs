using System.Collections.Generic;
using System.Linq;
namespace PizzaApi
{
    public class Pizza : IPurchasable
    {
        public string Name { get; set; }
        public int Price { get { return BasePrice + ExtraIngredients.Sum(ingredient => ingredient.Price); } }
        public int BasePrice { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Ingredient> ExtraIngredients { get; set; }
        public Pizza()
        {
            ExtraIngredients = new List<Ingredient>();
        }


    }
}