using System.Collections.Generic;

namespace PizzaApi
{
    public class ModifyPizzaDTO
    {
        public int Id { get; set; }
        public List<int> Ingredients { get; set; }
    }
}
