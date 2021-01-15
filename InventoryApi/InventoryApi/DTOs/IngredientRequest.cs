using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientApi.DTOs
{
    public class IngredientRequest
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
