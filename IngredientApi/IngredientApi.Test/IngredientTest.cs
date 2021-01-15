using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientApi.Persistence;
using NUnit.Framework;

namespace IngredientApi.Test
{
    class IngredientTest
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
