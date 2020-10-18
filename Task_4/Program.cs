using System;

namespace Task_4
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Say("Введiть ключ доступу:");
            string key = Console.ReadLine()?.ToUpper();
            ApplicationLicense.ChooseLicense(key);
            
            Calculator.Run();
        }

        public static void Say(string phrase, ConsoleColor color = ConsoleColor.DarkGray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(phrase);
            Console.ResetColor();
        }
    }
}