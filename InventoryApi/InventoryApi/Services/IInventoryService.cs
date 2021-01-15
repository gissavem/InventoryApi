using System.Collections.Generic;
using InventoryApi.DTOs;
using InventoryApi.Persistence;

namespace InventoryApi.Services
{
    public interface IInventoryService
    {
        public InventoryResponse GetInventory();
        public bool CheckIfIngredientsAreInStock(IEnumerable<Ingredient> ingredients);
        public void AddIngredientToInventory(IngredientRequest ingredient);
        public void IncreaseAmountOfAllIngredients(IngredientRequest ingredient);

    }
}
