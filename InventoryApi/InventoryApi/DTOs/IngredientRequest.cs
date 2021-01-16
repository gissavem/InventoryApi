using System.ComponentModel.DataAnnotations;

namespace InventoryApi.DTOs
{
    public class IngredientRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
