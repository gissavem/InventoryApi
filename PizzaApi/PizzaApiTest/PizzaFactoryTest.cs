using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaApi;

namespace PizzaApiTest
{
    [TestClass]
    public class PizzaFactoryTest
    {
        [TestMethod]
        public void ShouldReturnHawaii()
        {
            var factory = new HawaiiFactory();
            var expected = 4;

            var hawaii = factory.GetPizza();
            var actual = hawaii.Ingredients.Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldReturnKebab()
        {
            var factory = new KebabFactory();
            var expected = 9;

            var hawaii = factory.GetPizza();
            var actual = hawaii.Ingredients.Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldReturnQuatrioStagioni()
        {
            var factory = new QuatroStagioniFactory();
            var expected = 7;

            var hawaii = factory.GetPizza();
            var actual = hawaii.Ingredients.Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldReturnMargerita()
        {
            var factory = new MargeritaFactory();
            var expected = 2;

            var hawaii = factory.GetPizza();
            var actual = hawaii.Ingredients.Count;

            Assert.AreEqual(actual, expected);
        }
    }
}
