using System;
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

        public List<string> GetNamesOfMissingIngredients(IEnumerable<Ingredient> orderIngredients)
        {
            return (from orderIngredient in orderIngredients 
                select context.Ingredients.SingleOrDefault(i => i.Name == orderIngredient.Name && i.Amount < orderIngredient.Amount)
                into ingredient 
                where ingredient is not null 
                select ingredient.Name).ToList();
        }

        public void RemoveIngredientsFromInventory(IEnumerable<Ingredient> orderIngredients)
        {
            foreach (var orderIngredient in orderIngredients)
            {
                context.Ingredients.First(i => i.Name == orderIngredient.Name).Amount -= orderIngredient.Amount;
            }
            context.SaveChanges();
        }

        public void AddIngredientToInventory(IngredientRequest request)
        {
            if (request.Name == "all")
            {
                AddAmountToAllIngredients(request.Amount);
                return;
            }
            var ingredient = context.Ingredients.SingleOrDefault(i => i.Name == request.Name);
            if (ingredient is null)
            {
                throw new KeyNotFoundException($"{request.Name} is not a valid ingredient and thus does not exist in the database.");
            }
            ingredient.Amount += request.Amount;
            context.SaveChanges();
        }

        private void AddAmountToAllIngredients(int amountToIncrease)
        {
            context.Ingredients.ForEachAsync(i => i.Amount += amountToIncrease).GetAwaiter().GetResult();
            context.SaveChanges();
        }
    }
}
