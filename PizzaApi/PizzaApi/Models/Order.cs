using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApi
{
    public class Order
    {
        public bool IsEmpty => !Pizzas.Any() && !Drinks.Any();
        public Dictionary<int,Pizza> Pizzas { get; set; }
        public Dictionary<int,Drink> Drinks { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public Status Status;

        public Order()
        {
            Pizzas = new Dictionary<int, Pizza>();
            Drinks = new Dictionary<int, Drink>();
        }
    }
}