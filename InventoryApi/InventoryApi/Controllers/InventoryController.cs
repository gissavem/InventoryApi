using System;
using System.Diagnostics;
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
                Debug.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}