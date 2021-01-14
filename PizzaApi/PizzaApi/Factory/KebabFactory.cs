namespace PizzaApi
{
    public class KebabFactory : PizzaFactory
    {
        public override Pizza GetPizza()
        {
            return GetPizzaFromMenu(Pizzas.Kebab);
        }
    }
}
