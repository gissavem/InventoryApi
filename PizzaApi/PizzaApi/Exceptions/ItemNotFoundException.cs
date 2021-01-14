using System;

namespace PizzaApi
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string id) : base($"Item \"{id}\" was not found.")
        {
        }
    }
}
