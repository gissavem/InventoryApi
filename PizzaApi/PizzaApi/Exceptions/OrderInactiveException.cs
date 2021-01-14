using System;

namespace PizzaApi
{
    public class OrderInactiveException :Exception
    {
        public OrderInactiveException(string message) :base(message)
        {
            
        }
    }
}
