using Microsoft.EntityFrameworkCore;

namespace ingredient_api.Persistence
{
    public class IngredientDbContext : DbContext
    {
        public IngredientDbContext(DbContextOptions<IngredientDbContext> options) : base(options)
        {
        }
    }
}
