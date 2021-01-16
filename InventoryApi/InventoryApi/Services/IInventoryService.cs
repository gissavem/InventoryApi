using System.Collections.Generic;
using InventoryApi.DTOs;
using InventoryApi.Persistence;

namespace InventoryApi.Services
{
    public interface IInventoryService
    {
        public InventoryResponse GetInventory();
        public void AddIngredientToInventory(IngredientRequest ingredient);
        public List<string> GetNamesOfMissingIngredients(IEnumerable<Ingredient> orderIngredients);
        public void RemoveIngredientsFromInventory(IEnumerable<Ingredient> orderIngredients);

    }
}
