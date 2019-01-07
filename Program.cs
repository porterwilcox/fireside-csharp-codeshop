using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleShop
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // initial data
            Console.Clear();
            Console.Write("Spinning up the code shop.");
            Item runners = new Item("Runners", 13, 17.99m);
            Item cams = new Item("Cams", 6, 79.99m);
            Item stoppers = new Item("Stoppers", 3, 64.99m, true);
            List<Item> items = new List<Item>() { runners, cams, stoppers };
            Shop climbOn = new Shop("Climb On", items);
            Thread.Sleep(1000);

            // while using the shop
            while (true)
            {
                Console.Clear();
                climbOn.DrawShop();
                climbOn.DrawHelp();
                int choice;
                while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3))
                {
                    System.Console.WriteLine("Please enter a vaild number.");
                }
                switch(choice)
                {
                    case 1:
                    climbOn.Purchase();
                    break;
                    case 2:
                    climbOn.Add();
                    break;
                    default:
                    climbOn.Edit();
                    break;
                }
            }
        }
    }
}
