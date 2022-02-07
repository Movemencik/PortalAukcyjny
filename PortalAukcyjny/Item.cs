using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Item
    {
        public Item(string name, string category, int price, bool awarded)
        {
            Name = name;
            Category = category;
            Price = price;
            Awarded = awarded;
        }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Awarded { get; set; }
    }
}
