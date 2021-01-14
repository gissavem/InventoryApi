namespace PizzaApi
{
    public class Drink : IPurchasable
    {
        public string Name { get; }
        public int Price { get; }

        public Drink(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}