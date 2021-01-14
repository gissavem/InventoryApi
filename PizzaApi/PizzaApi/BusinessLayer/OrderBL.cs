using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApi
{
    public class OrderBL
    {
        private readonly CartSingleton _cart;
        private readonly OrderStoreSingleton _orderStore;

        public OrderBL(CartSingleton cart, OrderStoreSingleton orderStore)
        {
            _cart = cart;
            _orderStore = orderStore;
        }
        public int SaveOrderInCartToOrderStore()
        {
            var orderId = _orderStore.Orders.Count;
            _cart.Order.Status = Status.InProgress;
            _cart.Order.OrderTime = DateTime.Now;
            _orderStore.Orders.Add(orderId, _cart.Order);
            _cart.Order = new Order();
            return orderId;
        }

        public IEnumerable<KeyValuePair<int, Order>> GetAllActiveOrders()
        {
            return 
                _orderStore
                .Orders
                .Where(order => order.Value.Status == Status.InProgress);
        }

        public Order UpdateStatusOfOrderInRequest(UpdateOrderStatusRequest request)
        {
            var order = _orderStore.Orders[request.Id];
            if (order.Status != Status.InProgress)
            {
                throw new OrderInactiveException(request.Id.ToString());
            }
            order.Status = request.OrderSuccessful ? Status.Completed : Status.Cancelled;
            return order;
        }
    }
}
