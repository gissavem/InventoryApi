namespace IngredientApi.Persistence
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool InStock => Amount > 0;
    }
}
