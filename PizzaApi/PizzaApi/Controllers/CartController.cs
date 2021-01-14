using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartSingleton _cart;
        private readonly CartBL _cartBL;

        public CartController(CartSingleton cart, CartBL cartBL)
        {
            _cart = cart;
            _cartBL = cartBL;
        }
        [HttpGet]
        public ActionResult GetCartContents()
        {
            return _cart.Order.IsEmpty ? Ok("Your cart is empty") : Ok(_cart.Order);
        }
        [HttpPost]
        public ActionResult AddItemsToCart([FromBody] AddToOrderRequest request)
        {
            try
            {
                _cartBL.AddItemsFromRequestToCart(request);
            }
            catch (ItemNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPatch]
        public ActionResult UpdatePizzasInCart([FromBody] ModifyOrderRequest request)
        {
            try
            {
                _cartBL.UpdatePizzasAsPerRequest(request);
            }
            catch (ItemNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("There was no pizza with that id in your cart.");
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult RemoveItemsInCart([FromBody] RemoveItemsRequest request)
        {
            _cartBL.RemoveItemsInRequest(request);
            return NoContent();
        }
    }
}
