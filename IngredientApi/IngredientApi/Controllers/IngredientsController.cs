using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IngredientApi.Persistence;

namespace IngredientApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientDbContext dbContext;


        public IngredientsController(IngredientDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> Get()
        {
            dbContext.Ingredients.Add(new Ingredient()
            {
                Amount = 10,
                Name = "carrot"
            });
            dbContext.SaveChanges();
            try
            {
                return dbContext.Ingredients;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("{name}")]
        public ActionResult<Ingredient> GetByName(string name)
        {
            try
            {
                var ingredient = dbContext.Ingredients.SingleOrDefault(i => i.Name == name);
                if (ingredient is null)
                {
                    return NotFound();
                }

                return ingredient;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return StatusCode(500);
            }
        }
    }
}