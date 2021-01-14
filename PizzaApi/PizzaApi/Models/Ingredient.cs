namespace PizzaApi
{
    public  class Ingredient : IPurchasable
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}