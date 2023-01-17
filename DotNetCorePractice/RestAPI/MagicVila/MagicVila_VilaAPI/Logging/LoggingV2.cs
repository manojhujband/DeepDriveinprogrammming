namespace MagicVila_VilaAPI.Logging
{
    public class LoggingV2 : ILogging

    {
        public void log(string message, string type)
        {
            if (type == "error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Error -" + message);
            }
            else
            {
                if (type == "warning")
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Error -" + message);
                    Console.BackgroundColor = ConsoleColor.Green;
                }

            }
        }
    }
}
