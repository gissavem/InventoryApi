using System.Collections.Generic;

namespace InventoryApi.DTOs
{
    public class InventoryResponse
    {
        public Dictionary<string,int> Ingredients { get; set; } = new Dictionary<string, int>();
    }
}
