using System.Collections.Generic;

namespace PizzaApi
{
    public class AddToOrderRequest
    {
        public List<PizzaDTO> Pizzas { get; set; }
        public List<int> Drinks { get; set; }
    }
}
