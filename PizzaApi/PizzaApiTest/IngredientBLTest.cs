using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaApi;
using System.Collections.Generic;

namespace PizzaApiTest
{
    [TestClass]
    public class IngredientBLTest
    {
        [TestMethod]
        public void GetIngredientsWithoutDuplicates_ShouldReturnHamAndOnion()
        {
            var ingredientBL = new IngredientBL();
            var expectedHam = "Ham";
            var expectedOnion = "Onion";
            var ids = new List<int>() { 1, 1, 4 };

            var ingredients = ingredientBL.GetIngredients(ids);

            Assert.AreEqual(expectedHam, ingredients[0].Name);
            Assert.AreEqual(expectedOnion, ingredients[1].Name);

        }

        [TestMethod]
        public void CreateIngredientFromString_ShouldReturnKebba()
        {
            var ingredientBL = new IngredientBL();
            var expected = "Kebab";

           var ingredient = ingredientBL.CreateIngredientFromString("Kebab");

            Assert.AreEqual(expected, ingredient.Name);
        }
    }
}
