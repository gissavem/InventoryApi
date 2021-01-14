namespace PizzaApi
{
    public class QuatroStagioniFactory : PizzaFactory
    {
        public override Pizza GetPizza()
        {
            return GetPizzaFromMenu(Pizzas.QuatroStagioni);
        }
    }
}
