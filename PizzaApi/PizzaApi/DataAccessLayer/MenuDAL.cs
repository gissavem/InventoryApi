using System;
using System.IO;
using System.Text.Json;

namespace PizzaApi
{
    public class MenuDAL
    {
        private const string MENU_PATH = @"Files/menu.json";
        public string ReadMenuFromFile()
        {
            var menu = File.ReadAllText(MENU_PATH);

            return menu;
        }

        public Pizza GetPizzaFromJsonMenu(Pizzas pizzaType)
        {
            var menu = ReadMenuFromFile();
            var deserializedMenu = JsonSerializer.Deserialize<Menu>(menu);

            foreach (var pizza in deserializedMenu.Pizzas)
            {
                if (pizzaType.ToString() == pizza.Name.RemoveSpacesFromString())
                {
                    return pizza;
                }
            }
            throw new ItemNotFoundException(pizzaType.ToString());
        }
    }
}
