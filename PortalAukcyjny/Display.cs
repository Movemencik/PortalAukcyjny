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
        private static bool IsCorrectKeyItem(string klawisz)
        {
            List<string> dopuszczalneKlawisze = new List<string>
            {
                "1", "2", "3", "4", "5", "6"
            };
            if (dopuszczalneKlawisze.Contains(klawisz))
                return true;
            else
                return false;
        }
        private static bool IsCorrectKeyCard(string klawisz)
        {
            List<string> dopuszczalneKlawisze = new List<string>
            {
                "0001", "0002", "0003", "0004"
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
        public static void ShowAllItems(List<Item> service)
        {
            Console.Clear();
            Console.WriteLine("LISTA PRZEDMIOTÓW NA AUKCJI");
            Console.WriteLine("---------------------------");
            int x = 1;
            foreach (Item item in service)
            {
                if (item.Awarded == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{x++}. {item.Name} | {item.Category} | {item.Price} PLN");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{x++}. {item.Name} | {item.Category} | {item.Price} PLN");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static int ItemSelection(List<Item> service) 
        {
            Console.Clear();
            ShowAllItems(service);
            Console.WriteLine("");
            Console.Write("PODAJ NUMER PRODUKTU KTÓRY CHCESZ ZAKUPIĆ: ");
            string key = Console.ReadLine();
            bool IsCorrect = IsCorrectKeyItem(key);
            while (!IsCorrect)
            {
                ShowAllItems(service);
                key = Console.ReadLine();
                IsCorrect = IsCorrectKeyItem(key);
            }
            return int.Parse(key);
        }
        public static int CreditCardSelection()
        {
            Console.WriteLine("PODAJ NUMER KARTY KREDYTOWEJ (CZTERY CYFRY):");
            string key = Console.ReadLine();
            bool IsCorrect = IsCorrectKeyCard(key);
            while (!IsCorrect)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NIEPRAWIDŁOWY NUMER KARTY");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("PODAJ NUMER KARTY KREDYTOWEJ (CZTERY CYFRY):");
                key = Console.ReadLine();
                IsCorrect = IsCorrectKeyCard(key);
            }
            return int.Parse(key);
        }
    }
}