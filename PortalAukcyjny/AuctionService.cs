using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class AuctionService
    {
        public AuctionService()
        {
            CreateItems();
            CreateCreditCards();
        }

        public List<Item> AllItems { get; set; } = new List<Item>();
        public List<CreditCard> AllCreditCards { get; set; } = new List<CreditCard>();
        public List<Item> AllItemsOrderBy
        {
            get { return AllItems.OrderByDescending(x => x.Awarded).ToList(); }
        }
        public void CreateItems()
        {
            AllItems.Add(new Item("iPhone 12 PRO", "elektronika", 4600, true));
            AllItems.Add(new Item("Konsola Playstaion 5", "elektronika", 2899, false));
            AllItems.Add(new Item("Bluza Adidas Męska Szara", "odzież", 249, true));
            AllItems.Add(new Item("Spodnie Wrandler Arizona", "odzież", 189, false));
            AllItems.Add(new Item("Basen ogrodowy Premium", "dom i ogród", 1199, false));
            AllItems.Add(new Item("Krzesło skandynawskie granatowe", "dom i ogród", 4600, false));
        }
        private void CreateCreditCards()
        {
            AllCreditCards.Add(new CreditCard("Visa", 001, 100));
            AllCreditCards.Add(new CreditCard("Mastercard", 002, 10000));
            AllCreditCards.Add(new CreditCard("American Express", 003, 3000));
            AllCreditCards.Add(new CreditCard("Diners Club", 004, 1000));
        }
        public static void PurchaseItem(int choice, int cc, List<Item> itmes, List<CreditCard> credits, bool xs)
        {
            while (!xs)
            {
                if (itmes[choice - 1].Price <= credits[cc - 1].Fundslimit)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Kupiłeś przedmiot: {itmes[choice - 1].Name}");
                    Console.WriteLine($"Cena: {itmes[choice - 1].Price}");
                    Console.WriteLine($"Płatność kartą: {credits[cc - 1].Name} (nr karty: 000{credits[cc - 1].Id})");
                    Console.WriteLine("Zakup opłacony.");
                    xs = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"NIEWYSTARCZAJĄCY LIMIT NA RACHUNKU KARTY");
                    Console.ForegroundColor = ConsoleColor.White;
                    cc = Display.CreditCardSelection();
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void AddItem(AuctionService service)
        {
            Console.Clear();
            Console.WriteLine("PODAJ NAZWĘ PRZEDMIOTU, KTÓRY CHCESZ SPRZEDAĆ: ");
            string nnazwa = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("PODAJ KATEGORIĘ PRZEDMIOTU, DO KTÓREJ NALEŻY PRODUKT: ");
            string kkategoria = Console.ReadLine();
            int x = XPrice();
            bool y = YAwarded();
            service.AllItems.Add(new Item(nnazwa, kkategoria, x, y));
        }
        private static int XPrice()
        {
            Console.Clear();
            Console.Write("PODAJ CENĘ PRZEDMIOTU, KTÓRĄ CHCESZ OTRZYMAĆ: ");
            string price = Console.ReadLine();
            int convert;
            bool canconvert = int.TryParse(price, out convert);
            while (!canconvert)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NIEPRAWIDŁOWA CENA PRZEDMIOTU");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.Write("PODAJ CENĘ PRZEDMIOTU, KTÓRĄ CHCESZ OTRZYMAĆ: ");
                price = Console.ReadLine();
                canconvert = int.TryParse(price, out convert);

            }
            return convert;
        }
        private static bool YAwarded()
        {
            Console.Clear();
            Console.Write("NAPISZ 'tak' JEŻELI PRZEDMIOT MA BYĆ PROMOWANY: ");
            string yaw = Console.ReadLine();
            if (yaw == "tak")
            {
                return true;
            }
            else
                return false;
        }
    }
}