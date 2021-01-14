namespace PizzaApi
{
    public class CartSingleton
    {
        public Order Order;

        public CartSingleton()
        {
            Order = new Order();
        }

    }
}
