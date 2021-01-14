namespace PizzaApi
{
    public abstract class PizzaFactory 
    {
        
        private readonly MenuDAL _menuDAL;

        protected PizzaFactory()
        {
            _menuDAL = new MenuDAL();
        }

        protected Pizza GetPizzaFromMenu(Pizzas pizzaType)
        {
            return _menuDAL.GetPizzaFromJsonMenu(pizzaType);
        }

        public abstract Pizza GetPizza();
    }
}
