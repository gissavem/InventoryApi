namespace PizzaApi
{
    public class MenuBL
    {
        private readonly MenuDAL menuDAL;
      
        public MenuBL()
        {
            menuDAL = new MenuDAL();
        }
        public string GetMenu()
        {
            var menu = menuDAL.ReadMenuFromFile();
            return menu;
        }
    }
}
