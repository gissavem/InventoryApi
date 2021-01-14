using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaApi;

namespace PizzaApiTest
{
    [TestClass]
    public class IngredientFactoryTest
    {
        [TestMethod]
        public void GetKebab_ShouldCostTwenty()
        {
            var factory = new IngredientFactory();
            var expectedCost = 20;
            var expectedName = "Kebab";

            var ingredient = factory.GetKebab();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetCilantro_ShouldCostTwenty()
        {
            var factory = new IngredientFactory();
            var expectedCost = 20;
            var expectedName = "Cilantro";

            var ingredient = factory.GetCilantro();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetShrimp_ShouldCostFifteen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 15;
            var expectedName = "Shrimp";

            var ingredient = factory.GetShrimp();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetArtichoke_ShouldCostFifteen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 15;
            var expectedName = "Artichoke";

            var ingredient = factory.GetArtichoke();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetClam_ShouldCostFifteen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 15;
            var expectedName = "Clam";

            var ingredient = factory.GetClam();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetHam_ShouldCostTen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 10;
            var expectedName = "Ham";

            var ingredient = factory.GetHam();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetPineapple_ShouldCostTen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 10;
            var expectedName = "Pineapple";

            var ingredient = factory.GetPineapple();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetMushrooms_ShouldCostTen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 10;
            var expectedName = "Mushrooms";

            var ingredient = factory.GetMushrooms();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetOnion_ShouldCostTen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 10;
            var expectedName = "Onion";

            var ingredient = factory.GetOnion();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }

        [TestMethod]
        public void GetKebabSauce_ShouldCostTen()
        {
            var factory = new IngredientFactory();
            var expectedCost = 10;
            var expectedName = "Kebab Sauce";

            var ingredient = factory.GetKebabSauce();

            Assert.AreEqual(ingredient.Name, expectedName);
            Assert.AreEqual(ingredient.Price, expectedCost);
        }




    }
}
