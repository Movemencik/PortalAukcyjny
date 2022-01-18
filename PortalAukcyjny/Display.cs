using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Display
    {
        private static void ShowStartScreen(bool firstTime)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" WYBIERZ OPCJĘ:");
            Console.WriteLine();
            Console.WriteLine(" 1 => ZAKUP");
            Console.WriteLine();
            Console.WriteLine(" 2 => SPRZEDAŻ");
            Console.WriteLine();
            Console.WriteLine(" 3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine();
            if (firstTime)
                Console.Write("Naciśnij 1, 2 lub 3: ");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wcisnąłeś nieprawidłowy klawisz.");
                Console.Write("Naciśnij 1, 2 lub 3: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static bool IsCorrectKey(string klawisz)
        {
            List<string> dopuszczalneKlawisze = new List<string>
            {
                "1", "2", "3"
            };
            if (dopuszczalneKlawisze.Contains(klawisz))
                return true;
            else
                return false;
        }
        public static int DisplayStartScreen()
        {
            ShowStartScreen(true);
            string key = Console.ReadLine();
            bool IsCorrect = IsCorrectKey(key);
            while (!IsCorrect)
            {
                ShowStartScreen(false);
                key = Console.ReadLine();
                IsCorrect = IsCorrectKey(key);
            }

            return int.Parse(key);
        }
    }
}
