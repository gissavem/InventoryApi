using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using PizzaApi.Integration;
using PizzaApi.Integration.InventoryApi;

namespace PizzaApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CartSingleton _cart;
        private readonly OrderBL _orderBL;
        private readonly InventoryApiService _inventoryApi;

        public OrderController(CartSingleton cart, OrderBL orderBL, InventoryApiService inventoryApi)
        {
            _cart = cart;
            _orderBL = orderBL;
            _inventoryApi = inventoryApi;
        }
        [HttpGet]
        public ActionResult GetOrders()
        {
            var orders = _orderBL.GetAllActiveOrders();
            
            return orders.Any() == false 
                ? Ok("No orders in store at the moment") 
                : Ok(orders);
        }
        [HttpPost]
        public ActionResult SaveCurrentOrder()
        {
            if (_cart.Order.IsEmpty)
            {
                return BadRequest("No items in cart");
            }

            try
            {
                _inventoryApi.ProcessOrder(_cart.Order);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(e.Message);
            }

            var orderId = _orderBL.SaveOrderInCartToOrderStore();

            return Ok("Contents in cart saved with order id: "+ orderId);

        }
        [HttpPatch]
        public ActionResult UpdateOrderStatus([FromBody]UpdateOrderStatusRequest request)
        {
            var order = new Order();
            try
            {
                order = _orderBL.UpdateStatusOfOrderInRequest(request);
            }
            catch (OrderInactiveException)
            {
                
                NotFound($"The order with id _{request.Id}_ is no longer active");
                
            }
            catch (KeyNotFoundException)
            {
                NotFound("No order with that ID was found");
                throw;
            }
            return Ok($"Order with id {request.Id} was updated to {order.Status}");
        }
    }
}
