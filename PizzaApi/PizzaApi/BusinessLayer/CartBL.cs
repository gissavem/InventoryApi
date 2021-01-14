using System.Collections.Generic;
using System.Linq;

namespace PizzaApi
{
    public class CartBL
    {
        private readonly CartSingleton _cart;
        private readonly PizzaBL _pizzaBL;
        private readonly DrinkBL _drinkBL;
        private readonly IngredientBL _ingredientBL;

        public CartBL(CartSingleton cart, PizzaBL pizzaBL, DrinkBL drinkBL, IngredientBL ingredientBL)
        {
            _cart = cart;
            _pizzaBL = pizzaBL;
            _drinkBL = drinkBL;
            _ingredientBL = ingredientBL;
        }
        public void AddItemsFromRequestToCart(AddToOrderRequest request)
        {
            var pizzasToAdd = request.Pizzas.Select(pizza => _pizzaBL.CreatePizza(pizza)).ToList();
            var drinksToAdd = request.Drinks.Select(drink => _drinkBL.CreateDrink(drink)).ToList();
            StoreCollectionInCart(pizzasToAdd, drinksToAdd);
        }
        public void UpdatePizzasAsPerRequest(ModifyOrderRequest request)
        {
            foreach (var orderItem in request.Pizzas)
            {
                _cart.Order.Pizzas[orderItem.Id].ExtraIngredients =
                    _ingredientBL.GetIngredients(orderItem.Ingredients);
            }
            UpdateTotalPrice();
        }
        public void RemoveItemsInRequest(RemoveItemsRequest request)
        {
            foreach (var id in request.PizzaIds.Where(id => _cart.Order.Pizzas.ContainsKey(id)))
            {
                _cart.Order.Pizzas.Remove(id);
            }
            foreach (var id in request.DrinkIds.Where(id => _cart.Order.Drinks.ContainsKey(id)))
            {
                _cart.Order.Drinks.Remove(id);
            }
            UpdateTotalPrice();
        }
        private void StoreCollectionInCart(IEnumerable<Pizza> pizzas, IEnumerable<Drink> drinks)
        {
            foreach (var pizza in pizzas)
            {
                _cart.Order.Pizzas.Add(_cart.Order.Pizzas.Count, pizza);
            }
            foreach (var drink in drinks)
            {
                _cart.Order.Drinks.Add(_cart.Order.Drinks.Count, drink);
            }
            UpdateTotalPrice();
        }
        private void UpdateTotalPrice()
        {
            _cart.Order.TotalPrice = 0;

            foreach (var drink in _cart.Order.Drinks)
            {
                _cart.Order.TotalPrice += drink.Value.Price;
            }
            foreach (var pizza in _cart.Order.Pizzas)
            {
                _cart.Order.TotalPrice += pizza.Value.Price;
            }
        }
    }
}
