using System.Collections.Generic;
using InventoryApi.Persistence;

namespace InventoryApi.DTOs
{
    public class ProcessOrderRequest
    {
        public List<Ingredient> Ingredients { get; set; }
    }
}