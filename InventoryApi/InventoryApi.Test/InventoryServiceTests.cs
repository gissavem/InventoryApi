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
            const int expectedResultingAmount = 13;

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
                Assert.AreEqual(expectedResultingAmount, context.Ingredients.First(i => i.Name == name).Amount);
            }
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
    }
}