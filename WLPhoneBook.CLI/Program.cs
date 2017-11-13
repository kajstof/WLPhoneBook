using System;
using WLPhoneBook.Library;

namespace WLPhoneBook.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Application needs one or more parameters");
            }
            else
            {
                PhoneBook phoneBook = new PhoneBook();
                string searchedText = args.Length > 0 ? args[0] : "";

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Searched text: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(searchedText);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Join(" | ", phoneBook.Header));
                Console.ResetColor();
                foreach (var r in phoneBook.SearchRecords(searchedText))
                {
                    Console.WriteLine(r.ToString());
                }
            }
        }
    }
}
