using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    class ImsHelper
    {
        public const string Abstandhalter = "\n--------------------------------------------------------------\n";

        public static string InputWithPrompt(string Eingabetext)
        {
            Console.WriteLine($"{Eingabetext}: ");
            string Eingabe = Console.ReadLine();

            return Eingabe;
        }

        public static int InputWithPromptInt(string Eingabetext)
        {
            int Eingabe;

            Console.WriteLine($"{Eingabetext}: ");
            do
            { } while (!int.TryParse(Console.ReadLine(), out Eingabe));

            return Eingabe;
        }
    }
}
