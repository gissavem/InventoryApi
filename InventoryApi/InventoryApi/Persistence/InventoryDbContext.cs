using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IngredientApi.Persistence
{
    public class InventoryDbContext : DbContext
    {
        private const string ValidIngredientsFileName = "valid-ingredients.json";
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Ignore(i => i.InStock)
                .HasData(GetIngredientsForSeed());
        }

        public DbSet<Ingredient> Ingredients { get; set; }

        private Ingredient[] GetIngredientsForSeed()
        {
            var validNames = JsonConvert.DeserializeObject<IEnumerable<string>>(File.ReadAllText(ValidIngredientsFileName));
            return validNames
                .Select((t, i) => new Ingredient {Id = i + 1, Name = t})
                .ToArray();
        }

    }
}