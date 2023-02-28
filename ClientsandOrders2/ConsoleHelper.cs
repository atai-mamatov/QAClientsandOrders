namespace ClientsandOrders2.CMD
{
    public static class ConsoleHelper
    {
        public static string GetString(string fieldname)
        {
            Console.WriteLine($"Please enter {fieldname}");
            string value = Console.ReadLine();

            return value;
        }

        public static int GetInt(string fieldname)
        {
            string value = GetString(fieldname);

            return int.Parse(value);
        }

        public static DateTime GetDateTime(string fieldname)
        {
            string value = GetString(fieldname);
            return DateTime
                .ParseExact(value, ConsoleConstants.DatePattern, null);
        }
    }
}
