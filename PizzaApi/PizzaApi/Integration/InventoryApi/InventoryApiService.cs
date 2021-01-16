using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RestSharp;

namespace PizzaApi.Integration.InventoryApi
{
    public class InventoryApiService
    {
        private readonly string inventoryApiUri;

        public InventoryApiService(IOptions<InventoryApiOptions> options)
        {
            inventoryApiUri = options.Value.BaseUri;
        }
        public void ProcessOrder(Order order)
        {
            var ingredients = GetAllIngredientsInOrder(order);
            var processOrderRequest = new ProcessOrderRequest
            {
                Ingredients = MapIngredientsForRequest(ingredients)
            };
            var client = new RestClient(inventoryApiUri + "/inventory");
            var request = new RestRequest();
            request.AddJsonBody(processOrderRequest);

            var response = client.Post(request);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new BadHttpRequestException(response.ErrorMessage);
            }
        }

        private List<IngredientDTO> MapIngredientsForRequest(IEnumerable<Ingredient> ingredients)
        {
            return (from ingredient in ingredients
                    group ingredient by ingredient.Name
                    into g
                    select new IngredientDTO { Name = g.Key, Amount = g.Count()})
                .ToList();
        }

        private IEnumerable<Ingredient> GetAllIngredientsInOrder(Order order)
        {
            var ingredientsInOrder = new List<Ingredient>();
            foreach (var (_, pizza) in order.Pizzas)
            {
                ingredientsInOrder.AddRange(pizza.ExtraIngredients);
                ingredientsInOrder.AddRange(pizza.Ingredients);
            }

            return ingredientsInOrder;
        }
    }
}
