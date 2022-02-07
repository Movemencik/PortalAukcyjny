using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CreditCard
    {
        public CreditCard(string name, int number, int amount)
        {
            Name = name;
            Id = number;
            Fundslimit = amount;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fundslimit { get; set; }
    }
}
