namespace PizzaApi
{
    public static class StringFormater
    {
        public static string RemoveSpacesFromString(this string value)
        {
            return value.Replace(" ", "");
        }

    }
}
