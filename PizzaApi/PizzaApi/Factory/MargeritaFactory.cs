namespace PizzaApi
{
    public class MargeritaFactory : PizzaFactory
    {
        public override Pizza GetPizza()
        {
            return GetPizzaFromMenu(Pizzas.Margerita);
        }

    }
}
