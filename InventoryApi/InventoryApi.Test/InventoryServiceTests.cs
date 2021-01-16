using System.Collections.Generic;
using System.Linq;
using InventoryApi.DTOs;
using InventoryApi.Persistence;
using InventoryApi.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace InventoryApi.Test
{
    [TestFixture]
    public class InventoryServiceTests
    {
        private DbContextOptions<InventoryDbContext> options;
        private SqliteConnection connection;

        [SetUp]
        public void Initialize()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseSqlite(connection)
                .Options;
        }

        [TearDown]
        public void Cleanup()
        {
            connection.Close();
        }

        #region AddIngredientTests
        [Test]
        public void AddIngredientToInventory_ShouldNotThrowException()
        {
            //Arrange
            const string name = "cheese";
            const int amount = 3;
            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
            }
            //Act & Assert
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                service.AddIngredientToInventory(new IngredientRequest
                {
                    Amount = amount,
                    Name = name
                });
            }
        }
        [Test]
        public void AddInvalidIngredientToInventory_ShouldThrowKeyNotFoundException()
        {
            //Arrange
            const string name = "carrot";
            const int amount = 10;
            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
            }
            //Act
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                Assert.Throws<KeyNotFoundException>(() =>
                {
                    service.AddIngredientToInventory(new IngredientRequest
                    {
                        Amount = amount,
                        Name = name
                    });
                });
            }
        }
        [Test]
        public void AddAmountToIngredientInStock_NewTotalAmountShouldBeCorrect()
        {
            //Arrange
            const string name = "cheese";
            const int initialAmount = 10;
            const int amountToAdd = 3;
            const int expectedAmount = 13;

            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Ingredients.First(i => i.Name == name).Amount = initialAmount;
                context.SaveChanges();
            }
            //Act
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                service.AddIngredientToInventory(new IngredientRequest
                {
                    Amount = amountToAdd,
                    Name = name
                });
            }
            //Assert
            using (var context = new InventoryDbContext(options))
            {
                Assert.AreEqual(expectedAmount, context.Ingredients.First(i => i.Name == name).Amount);
            }
        }
        [Test]
        public void AddToAllIngredientInStock_AllAmountsShouldIncrease()
        {
            //Arrange
            const string all = "all";
            const int initialAmount = 0;
            const int amountToAdd = 3;
            const int expectedAmount = 3;
            bool isAnyIngredientNotWhatExpected;

            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Ingredients.ForEachAsync(i => i.Amount = initialAmount).GetAwaiter().GetResult();
                context.SaveChanges();
            }
            //Act
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                service.AddIngredientToInventory(new IngredientRequest
                {
                    Amount = amountToAdd,
                    Name = all
                });
            }
            //Assert
            using (var context = new InventoryDbContext(options))
            {
                isAnyIngredientNotWhatExpected = context.Ingredients.Any(i => i.Amount != expectedAmount);
            }
            Assert.AreEqual(false, isAnyIngredientNotWhatExpected);
        }

        #endregion

        #region GetInventoryTests
        [Test]
        public void GetInventory_ShouldReturnDictionaryWithAllIngredients()
        {
            //Arrange
            int expectedNumberOfIngredients;
            InventoryResponse response;
            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
                expectedNumberOfIngredients = context.Ingredients.Count();
            }

            //Act
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                response = service.GetInventory();
            }

            //Assert
            Assert.AreEqual(expectedNumberOfIngredients, response.Ingredients.Count);
        }

        #endregion

        #region IngredientsInStockTests

        [Test]
        public void GetNamesOfMissingIngredients_AllIngredientsInStock_ShouldReturnEmptyList()
        {
            //Arrange
            var ingredientsToLookFor = new List<Ingredient>
            {
                new Ingredient{Amount = 3, Name = "cheese"},
                new Ingredient{Amount = 3, Name = "ham"},
            };
            const int amountInInventory = 10;
            const int expectedCount = 0;
            int actualCount;

            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Ingredients.ForEachAsync(i => i.Amount = amountInInventory).GetAwaiter().GetResult();
                context.SaveChanges();
            }

            //Act
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                actualCount = service.GetNamesOfMissingIngredients(ingredientsToLookFor).Count;
            }

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void GetNamesOfMissingIngredients_IngredientsMissing_ShouldReturnListWithOneItem()
        {
            //Arrange
            const string pineapple = "pineapple";
            List<string> missingIngredientNames;
            var ingredientsToLookFor = new List<Ingredient>
            {
                new Ingredient{Amount = 3, Name = "cheese"},
                new Ingredient{Amount = 3, Name = "ham"},
                new Ingredient{Amount = 5, Name = pineapple},
            };
            const int amountInInventory = 3;
            const int expectedCount = 1;

            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Ingredients.ForEachAsync(i => i.Amount = amountInInventory).GetAwaiter().GetResult();
                context.SaveChanges();
            }

            //Act
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                missingIngredientNames = service.GetNamesOfMissingIngredients(ingredientsToLookFor);
            }

            //Assert
            Assert.AreEqual(expectedCount, missingIngredientNames.Count);
            Assert.AreEqual(true, missingIngredientNames.Contains(pineapple));

        }

        #endregion

        #region RemoveIngredientsTests

        [Test]
        public void RemoveIngredientsFromInventory_ShouldRemoveExpectedAmounts()
        {
            //Arrange
            const int amountToRemove = 3;
            const string cheese = "cheese";
            var orderIngredients = new List<Ingredient>
            {
                new Ingredient{Amount = amountToRemove, Name = cheese},
                new Ingredient{Amount = amountToRemove, Name = "ham"},
            };
            const int initialAmount = 5;
            const int expectedAmount = initialAmount - amountToRemove;
            using (var context = new InventoryDbContext(options))
            {
                context.Database.EnsureCreated();
                context.Ingredients.ForEachAsync(i => i.Amount = initialAmount).GetAwaiter().GetResult();
                context.SaveChanges();
            }
            //Act
            using (var context = new InventoryDbContext(options))
            {
                var service = new InventoryService(context);
                service.RemoveIngredientsFromInventory(orderIngredients);
            }
            //Assert
            using (var context = new InventoryDbContext(options))
            {
                Assert.AreEqual(expectedAmount, context.Ingredients.First(i => i.Name == cheese).Amount);
            }
        }

        #endregion
    }
}