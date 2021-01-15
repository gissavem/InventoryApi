using System.Collections.Generic;

namespace IngredientApi.DTOs
{
    public class InventoryResponse
    {
        public Dictionary<string,int> Ingredients { get; set; }
    }
}
