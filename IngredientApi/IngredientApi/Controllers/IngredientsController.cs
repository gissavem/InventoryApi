using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using IngredientApi.Persistence;
using IngredientApi.Services;

namespace IngredientApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IInventoryService inventoryService;


        public IngredientsController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        [HttpGet]
        public ActionResult GetIngredientsInInventory()
        {
            try
            {
                var inventory = inventoryService.GetInventory();
                return Ok(inventory.Ingredients);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}