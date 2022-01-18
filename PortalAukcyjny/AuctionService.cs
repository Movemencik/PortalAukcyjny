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
        public Item CurrentItems { get; set; }

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
    }
}
