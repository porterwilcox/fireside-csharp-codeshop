using System;
using System.Collections.Generic;

namespace ConsoleShop
{
    public class Shop
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public void DrawShop()
        {
            var ogColor = Console.ForegroundColor;
            System.Console.WriteLine($"You're at the {Name}.");
            for (int i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                if (item.OnSale) Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"{i + 1}. {item.Name} - {item.Quantity} left. ${item.Price}");
                Console.ForegroundColor = ogColor;
            }
            System.Console.WriteLine("");
        }

        public void DrawHelp()
        {
            System.Console.WriteLine("What do you want to do?\n1. Purchase an item\n2. Add an item.\n3. Edit an item.");
        }

        internal void Purchase()
        {
            Console.Clear();
            DrawShop();
            System.Console.WriteLine("What item do you want to purchase?");
            int choice;
            while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > Items.Count))
            {
                System.Console.WriteLine("Please enter a vaild number.");
            }
            Item item = Items[choice - 1];
            System.Console.WriteLine($"There are {item.Quantity} available. How many do you want?");
            while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 0 || choice > item.Quantity))
            {
                System.Console.WriteLine("Please enter a vaild number.");
            }
            item.Quantity -= choice;
            System.Console.WriteLine($"We'll bill you ${choice * item.Price} for the {item.Name}. Thanks for the business.");
            Console.ReadLine();
        }

        internal void Add()
        {
            Console.Clear();
            DrawShop();
            System.Console.WriteLine("What's the name of your item?");
            string name = Console.ReadLine();
            System.Console.WriteLine($"How many {name}'s are being added?");
            int quantity; 
            Int32.TryParse(Console.ReadLine(), out quantity);
            System.Console.WriteLine($"What is the price of a {name}");
            decimal price; 
            Decimal.TryParse(Console.ReadLine(), out price);
            System.Console.WriteLine("Is the item on sale? (y/n)");
            bool sale = Console.ReadLine().ToLower().Contains("n");
            Item item = new Item(name, quantity, price, sale);
            Items.Add(item);
            System.Console.WriteLine("Your item has been added! Thank you.");
            Console.ReadLine();
        }

        internal void Edit()
        {
            Console.Clear();
            DrawShop();
            System.Console.WriteLine("What item do you want to edit?");
            int choice;
            while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > Items.Count))
            {
                System.Console.WriteLine("Please enter a vaild number.");
            }
            Console.Clear();
            DrawShop();
            Item item = Items[choice - 1];
            // var props = typeof(Item).GetProperties();
            // foreach (var prop in props)
            // {
            //     System.Console.WriteLine($"{prop.Name}");
            // }
            // Console.ReadLine();
            System.Console.WriteLine($"What would you like to change on the {item.Name}?\n1. Name\n2. Quantity\n 3. Price\n 4. Sale Status");
            while (!Int32.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 4))
            {
                System.Console.WriteLine("Please enter a vaild number.");
            }
            switch(choice)
            {
                case 1:
                System.Console.WriteLine("enter a new name");
                item.Name = Console.ReadLine();
                break;
                case 2:
                System.Console.WriteLine("enter a new quantity");
                Int32.TryParse(Console.ReadLine(), out choice);
                item.Quantity = choice;
                break;
                case 3:
                System.Console.WriteLine("enter a new price");
                decimal price;
                Decimal.TryParse(Console.ReadLine(), out price);
                item.Price = price;
                break;
                default:
                System.Console.WriteLine("Change the sale status? (y/n)");
                if (Console.ReadLine().ToLower().Contains("n")) break;
                item.OnSale = !item.OnSale;
                break;
            }
        }
        public Shop(string name, List<Item> items)
        {
            Name = name;
            Items = items;
        }
    }
}