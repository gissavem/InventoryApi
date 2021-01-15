using System;
using System.Collections.Generic;
using System.Linq;
using IngredientApi.DTOs;
using IngredientApi.Persistence;

namespace IngredientApi.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IngredientDbContext context;

        public InventoryService(IngredientDbContext context)
        {
            this.context = context;
        }

        public InventoryResponse GetInventory()
        {
            throw new System.NotImplementedException();
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
