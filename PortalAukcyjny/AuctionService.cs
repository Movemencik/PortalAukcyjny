using Newtonsoft.Json;
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

        public List<Item> AllItems { get; set; }
        public List<CreditCard> AllCreditCards { get; set; }
        public List<Item> AllItemsOrderBy
        {
            get { return AllItems.OrderByDescending(x => x.Awarded).ToList(); }
        }
        public void CreateItems()
        {
            string path = Directory.GetCurrentDirectory() + "\\items.json";
            string text = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<Item>>(text);
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Id = i + 1;
            }
            AllItems = items;
        }
        private void CreateCreditCards()
        {
            string path = Directory.GetCurrentDirectory() + "\\creditcards.json";
            string text = File.ReadAllText(path);
            var creditcards = JsonConvert.DeserializeObject<List<CreditCard>>(text);
            for (int i = 0; i < creditcards.Count; i++)
            {
                creditcards[i].Id = i + 1;
            }
            AllCreditCards = creditcards;
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
    }
}
