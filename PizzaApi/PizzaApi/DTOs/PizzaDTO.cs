using System.Collections.Generic;

namespace PizzaApi
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public List<int> ExtraIngredients { get; set; }
    }
}
