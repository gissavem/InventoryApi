using System.Collections.Generic;
using System.Linq;

namespace PizzaApi
{
    public class IngredientBL
    {
        private readonly IngredientFactory _ingredientFactory;

        public IngredientBL()
        {
            _ingredientFactory = new IngredientFactory();
        }
        public List<Ingredient> GetIngredients(List<int> ingredientIDs)
        {
            var distinctIds = ingredientIDs.Distinct();
            return CreateIngredientsFromIds(distinctIds);
        }
        private List<Ingredient> CreateIngredientsFromIds(IEnumerable<int> ids)
        {
            var ingredients = new List<Ingredient>();
            foreach (var id in ids)
            {
                ingredients.Add(CreateIngredientFromId(id));
            }

            return ingredients;
        }
        private Ingredient CreateIngredientFromId(int id)
        {
            return id switch
            {
                (int) Ingredients.Ham => _ingredientFactory.GetHam(),
                (int) Ingredients.Pineapple => _ingredientFactory.GetPineapple(),
                (int) Ingredients.Mushrooms => _ingredientFactory.GetMushrooms(),
                (int) Ingredients.Onion => _ingredientFactory.GetOnion(),
                (int) Ingredients.KebabSauce => _ingredientFactory.GetKebabSauce(),
                (int) Ingredients.Shrimp => _ingredientFactory.GetShrimp(),
                (int) Ingredients.Clam => _ingredientFactory.GetClam(),
                (int) Ingredients.Artichoke => _ingredientFactory.GetArtichoke(),
                (int) Ingredients.Kebab => _ingredientFactory.GetKebab(),
                (int) Ingredients.Cilantro => _ingredientFactory.GetCilantro(),
                _ => throw new ItemNotFoundException("ingredient " + id)
            };
        }

        public Ingredient CreateIngredientFromString(string ingredientName)
        {
            return ingredientName.RemoveSpacesFromString() switch
            {
                "Ham" => _ingredientFactory.GetHam(),
                "Pineapple" => _ingredientFactory.GetPineapple(),
                "Mushrooms" => _ingredientFactory.GetMushrooms(),
                "Onion" => _ingredientFactory.GetOnion(),
                "KebabSauce" => _ingredientFactory.GetKebabSauce(),
                "Shrimp" => _ingredientFactory.GetShrimp(),
                "Clam" => _ingredientFactory.GetClam(),
                "Artichoke" => _ingredientFactory.GetArtichoke(),
                "Kebab" => _ingredientFactory.GetKebab(),
                "Cilantro" => _ingredientFactory.GetCilantro(),
                "Cheese" => _ingredientFactory.GetCheese(),
                "TomatoSauce" => _ingredientFactory.GetTomatoSauce(),
                "Peperoncino" => _ingredientFactory.GetPeperoncino(),
                "Tomato" => _ingredientFactory.GetTomato(),
                "Lettuce" => _ingredientFactory.GetLettuce(),
                _ => throw new ItemNotFoundException(ingredientName)
            };
        }
    }
}
