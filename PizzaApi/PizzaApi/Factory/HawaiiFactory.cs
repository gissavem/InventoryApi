namespace PizzaApi
{
    public class HawaiiFactory : PizzaFactory
    {
        public override Pizza GetPizza()
        {
            return GetPizzaFromMenu(Pizzas.Hawaii);
        }
    }
}
