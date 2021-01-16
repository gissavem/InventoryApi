using System.Collections.Generic;

namespace PizzaApi.Integration
{
    public class ProcessOrderRequest
    {
        public List<IngredientDTO> Ingredients { get; set; }

    }
}