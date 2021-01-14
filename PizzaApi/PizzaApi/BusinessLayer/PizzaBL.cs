using System.Collections.Generic;
using System.Linq;

namespace PizzaApi
{
    public class PizzaBL
    {
        private readonly MargeritaFactory _margeritaFactory;
        private readonly HawaiiFactory _hawaiiFactory;
        private readonly KebabFactory _kebabFactory;
        private readonly QuatroStagioniFactory _quatroStagioniFactory;
        private readonly IngredientBL _ingredientBL;

        public PizzaBL(IngredientBL ingredientBL)
        {
            _margeritaFactory = new MargeritaFactory();
            _hawaiiFactory = new HawaiiFactory();
            _kebabFactory = new KebabFactory();
            _quatroStagioniFactory = new QuatroStagioniFactory();
            _ingredientBL = ingredientBL;
        }
        public List<Pizza> GetAllPizzasOnMenu()
        {
            return new List<Pizza>
            {
                _margeritaFactory.GetPizza(),
                _hawaiiFactory.GetPizza(),
                _kebabFactory.GetPizza(),
                _quatroStagioniFactory.GetPizza()
            };
        }
        public Pizza CreatePizza(PizzaDTO pizzaDTO)
        {
            var pizza = CreatePizzaFromId(pizzaDTO.Id);
            if (pizzaDTO.ExtraIngredients.Any())
            {
                pizza.ExtraIngredients = _ingredientBL.GetIngredients(pizzaDTO.ExtraIngredients);
            }
            return pizza;
        }
        public Pizza CreatePizzaFromId(int id)
        {
            return id switch
            {
                (int) Pizzas.Margerita => _margeritaFactory.GetPizza(),
                (int) Pizzas.Hawaii => _hawaiiFactory.GetPizza(),
                (int) Pizzas.Kebab => _kebabFactory.GetPizza(),
                (int) Pizzas.QuatroStagioni => _quatroStagioniFactory.GetPizza(),
                _ => throw new ItemNotFoundException("Pizza "+id)
            };
        }
    }
}
