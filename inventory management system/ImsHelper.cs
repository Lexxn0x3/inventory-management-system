using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    class ImsHelper
    {
        public const string stringSeperator = "\n--------------------------------------------------------------\n";

        public static string InputWithPrompt(string promptText)
        {
            Console.WriteLine($"{promptText}: ");
            string Eingabe = Console.ReadLine();

            return Eingabe;
        }

        public static int InputWithPromptInt(string promptText)
        {
            int input;

            do
            {
                Console.WriteLine($"{promptText}: ");

            } 
            while (!int.TryParse(Console.ReadLine(), out input));

            return input;
        }
    }
}
