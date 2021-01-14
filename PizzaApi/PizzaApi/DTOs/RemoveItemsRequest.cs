using System.Collections.Generic;

namespace PizzaApi
{
    public class RemoveItemsRequest
    {
        public List<int> PizzaIds { get; set; }
        public List<int> DrinkIds { get; set; }

    }
}
