using InventoryApi.Persistence;
using NUnit.Framework;

namespace InventoryApi.Test
{
    public class IngredientTest
    {
        [Test]
        public void Ingredient_InStock_UnitTest()
        {
            const bool expected = false;
            var ingredient = new Ingredient()
            {
                Amount = 0,
                Name = "cheese"
            };
            Assert.AreEqual(expected, ingredient.InStock);
        }
    }
}
