using System.Collections.Generic;
using IngredientApi.DTOs;
using IngredientApi.Persistence;

namespace IngredientApi.Services
{
    public interface IInventoryService
    {
        public InventoryResponse GetInventory();
        public bool CheckIfIngredientsAreInStock(IEnumerable<Ingredient> ingredients);
        public void AddIngredientToInventory(IngredientRequest ingredient);
        public void IncreaseAmountOfAllIngredients(IngredientRequest ingredient);

    }
}
