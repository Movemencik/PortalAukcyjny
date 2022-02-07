using System;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            AuctionService service = new AuctionService();
            int number = Display.DisplayStartScreen();
            if (number == 1)
            {
                int choice = Display.ItemSelection(service.AllItemsOrderBy);
                Console.Clear();
                int cc = Display.CreditCardSelection();
                AuctionService.PurchaseItem(choice, cc, service.AllItemsOrderBy, service.AllCreditCards, false);
            }
            else if (number == 2)
            {
                AuctionService.AddItem(service);
                Display.ShowAllItems(service.AllItemsOrderBy);
            }
            else { }
        }
    }
}