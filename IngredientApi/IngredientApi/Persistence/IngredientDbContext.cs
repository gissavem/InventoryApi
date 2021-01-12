using Microsoft.EntityFrameworkCore;

namespace IngredientApi.Persistence
{
    public class IngredientDbContext : DbContext
    {
        public IngredientDbContext(DbContextOptions<IngredientDbContext> options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}