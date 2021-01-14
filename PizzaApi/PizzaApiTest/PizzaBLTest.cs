using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaApi;

namespace PizzaApiTest
{
    [TestClass]
    public class PizzaBLTest
    {
        [TestMethod]
        public void CreatePizzaFromId_ShouldCreateMargarita()
        {
            var ingredientBL = new IngredientBL();
            var pizzaBL = new PizzaBL(ingredientBL);
            var id = 1;
            var expected = "Margerita";
            var pizza = pizzaBL.CreatePizzaFromId(id);

            Assert.AreEqual(expected, pizza.Name);
        }
        [TestMethod]
        public void CreatePizza_ShouldCreateMargaritaWithMushrooms()
        {
            var margeritaFactory = new MargeritaFactory();
            var ingredientFactory = new IngredientFactory();
            var ingredientBL = new IngredientBL();
            var pizzaBL = new PizzaBL(ingredientBL);
            var pizzaDTO = new PizzaDTO
            {
                Id = 1,
                ExtraIngredients = new List<int>
                {
                    (int)Ingredients.Mushrooms
                }
            };
            var expected = margeritaFactory.GetPizza();
            expected.ExtraIngredients.Add(ingredientFactory.GetMushrooms());

            var pizza = pizzaBL.CreatePizza(pizzaDTO);

            Assert.AreEqual(expected.Name, pizza.Name);
            Assert.AreEqual(expected.ExtraIngredients[0].Name, pizza.ExtraIngredients[0].Name);
        }
        [TestMethod]
        public void GetAllPizzas_ShouldCreateAllPizzas()
        {
            var ingredientBL = new IngredientBL();
            var pizzaBL = new PizzaBL(ingredientBL);
            var expected = 4;

            var actual = pizzaBL.GetAllPizzasOnMenu();

            Assert.AreEqual(actual.Count, expected);

        }
    }
}
