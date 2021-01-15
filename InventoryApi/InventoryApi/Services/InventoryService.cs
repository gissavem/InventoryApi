using System.Collections.Generic;
using System.Linq;
using InventoryApi.DTOs;
using InventoryApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryApi.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly InventoryDbContext context;

        public InventoryService(InventoryDbContext context)
        {
            this.context = context;
        }

        public InventoryResponse GetInventory()
        {
            var response = new InventoryResponse();

            context.Ingredients
                .ForEachAsync(i => response.Ingredients.Add(i.Name,i.Amount))
                .GetAwaiter()
                .GetResult();

            return response;
        }

        public bool CheckIfIngredientsAreInStock(IEnumerable<Ingredient> ingredients)
        {
            throw new System.NotImplementedException();
        }

        public void AddIngredientToInventory(IngredientRequest request)
        {
            var ingredient = context.Ingredients.SingleOrDefault(i => i.Name == request.Name);
            if (ingredient is null)
            {
                throw new KeyNotFoundException($"{request.Name} is not a valid ingredient and thus does not exist in the database.");
            }
            ingredient.Amount += request.Amount;
            context.SaveChanges();
        }

        public void IncreaseAmountOfAllIngredients(IngredientRequest ingredient)
        {
            throw new System.NotImplementedException();
        }
    }
}
