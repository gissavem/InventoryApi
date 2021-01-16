using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using InventoryApi.DTOs;
using InventoryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
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
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
        public ActionResult AddIngredientsToInventory([FromBody] IngredientRequest request)
        {
            request.Name = request.Name.ToLowerInvariant();
            try
            {
                inventoryService.AddIngredientToInventory(request);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public ActionResult ProcessOrder([FromBody]ProcessOrderRequest request)
        {
            if (!request.Ingredients.Any())
            {
                return BadRequest("No ingredients in request");
            }
            try
            {
                var missingIngredients = inventoryService.GetNamesOfMissingIngredients(request.Ingredients);
                if (missingIngredients.Any())
                {
                    return NotFound("Not enough of ingredients in stock: " + missingIngredients.ToArray());
                }
                inventoryService.RemoveIngredientsFromInventory(request.Ingredients);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}