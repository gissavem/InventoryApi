using System.Collections.Generic;

namespace PizzaApi.Integration.InventoryApi
{
    public class ProcessOrderRequest
    {
        public List<IngredientDTO> Ingredients { get; set; }

    }
}