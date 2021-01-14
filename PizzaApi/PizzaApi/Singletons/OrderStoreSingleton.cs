using System.Collections.Generic;

namespace PizzaApi
{
    public class OrderStoreSingleton 
    {
        public Dictionary<int, Order> Orders;

        public OrderStoreSingleton()
        {
            Orders = new Dictionary<int, Order>();
        }
    }
}
