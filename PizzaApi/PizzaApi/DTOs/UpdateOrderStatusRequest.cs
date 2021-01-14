namespace PizzaApi
{
    public class UpdateOrderStatusRequest
    {
        public int Id { get; set; }
        public bool OrderSuccessful { get; set; }
    }
}
