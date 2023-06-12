using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Week3_DSA
{
    internal class Menu
    {
        private Transaction Order = new(); //Creates a New Transaction
        private Payment Payment = new(); //Calls Payment Class

        internal void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine( "Welcome to the ordering system! \n" +
                                "Please select an option \n" +
                                "1. Pizza\n" +
                                "2. Desserts\n" +
                                "3. Drinks\n" +
                                "4. Confirm Order\n" +
                                "0. Exit\n");

            Console.Write("Enter the Item NUMBER: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    ShowPizzaMenu();
                    break;
                case 2:
                    ShowDessertMenu();
                    break;
                case 3:
                    ShowDrinkMenu();
                    break;
                case 4:
                    ConfirmOrder();
                    break;
                default:
                    Prompts.CenterPrompt(Prompts.invalidInput);
                    Prompts.ContinueKey();
                    ShowMenu();
                    break;
            }
        }
        internal void GetQuantity(out int quantity) //Method to get Quantity
        {
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Prompts.CenterPrompt(Prompts.invalidInput);
            //Clears Input Area
                Console.SetCursorPosition(((Console.WindowWidth- Prompts.invalidInput.Length)/2), Console.CursorTop - 1);
                Prompts.CenterText("                                                                                ");
                Console.SetCursorPosition(((Console.WindowWidth - Prompts.invalidInput.Length) / 2), Console.CursorTop - 1);
            //Prompts User Again
                Prompts.CenterPrompt(Prompts.Quantity);
            }
        }

        internal void ShowPizzaMenu()
        {
            Console.Clear();
            string[] menuItems = 
            {
                "Pizza Menu",
                "",
                "1. Pepperoni",
                "2. Ham and Cheese",
                "3. Hawaiian",
                "0. Back" 
            };

            foreach (string menuItem in menuItems)
            {
                Prompts.CenterText(menuItem);
            }

            Prompts.CenterPrompt(Prompts.Choice);

            int choice;
         
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Prompts.CenterPrompt(Prompts.invalidInput);
                Prompts.ContinueKey();
                ShowPizzaMenu();                
            }

            Prompts.CenterPrompt(Prompts.Quantity);
            int quantity;
            switch (choice)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    GetQuantity(out quantity);
                    AddToOrder("Pepperoni", quantity, 399);
                    break;
                case 2:
                    GetQuantity(out quantity);
                    AddToOrder("Ham and Cheese", quantity, 399);
                    break;
                case 3:
                    GetQuantity(out quantity);
                    AddToOrder("Hawaiian", quantity, 399);
                    break;
                default:
                    Prompts.CenterPrompt(Prompts.invalidInput);
                    ShowPizzaMenu();
                    break;
            }
            ShowPizzaMenu();
        }
        internal void ShowDessertMenu()
        {
            Console.Clear();
            string[] menuItems = 
                {
                    "Dessert Menu",
                    " ",
                    "1. Halo - Halo (45 PHP)",
                    "2. Ice Cream (25 PHP)",
                    "0. Back"
                };

            foreach (string menuItem in menuItems)
            {
                Prompts.CenterText(menuItem);
            }

            Prompts.CenterPrompt(Prompts.Choice);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Prompts.CenterPrompt(Prompts.invalidInput);
                Prompts.ContinueKey();
                ShowDessertMenu();
            }

            Prompts.CenterPrompt(Prompts.Quantity);
            int quantity;
            switch (choice)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    GetQuantity(out quantity);
                    AddToOrder("Halo-halo", quantity, 45);
                    break;
                case 2:
                    GetQuantity(out quantity);
                    AddToOrder("Ice Cream", quantity, 25);
                    break;
                default:
                    Prompts.CenterPrompt(Prompts.invalidInput);
                    ShowDessertMenu();
                    break;
            }
            ShowDessertMenu();
        }

        internal void ShowDrinkMenu()
        {
            Console.Clear();
            string[] menuItems = 
                {
                    "Drink Menu",
                    " ",
                    "1. Coke (25 PHP)",
                    "2. Sprite (25 PHP)",
                    "0. Back"
                };

            foreach (string menuItem in menuItems)
            {
                Prompts.CenterText(menuItem);
            }

            Prompts.CenterPrompt(Prompts.Choice);
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Prompts.CenterPrompt(Prompts.invalidInput);
                Prompts.ContinueKey();
                ShowDrinkMenu();
            }
            Prompts.CenterPrompt(Prompts.Quantity);
            int quantity;
            switch (choice)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    GetQuantity(out quantity);
                    AddToOrder("Coke", quantity, 25);
                    break;
                case 2:
                    GetQuantity(out quantity);
                    AddToOrder("Sprite", quantity, 25);
                    break;
                default:
                    Prompts.CenterPrompt(Prompts.invalidInput);
                    ShowDrinkMenu();
                    break;
            }
            ShowDrinkMenu();
        }

        //Method to ADD ORDER
        internal void AddToOrder(string itemName, int quantity, int price)
        {
            for (int added = 0; added < quantity; added++) 
            {
                items newItem = new()
                {
                    Name = itemName,
                    price = price
                };
                Order.orders.Add(newItem);
            }

            Order.Total += (price * quantity); //Adds item price to the total amount
            Prompts.CenterText($"{quantity} {itemName}(s) added to your order.");
            Prompts.ContinueKey();
            Console.ReadKey();
        }

        //method to CONFIRM ORDER
        internal void ConfirmOrder()
        {
            Console.Clear();
            Console.WriteLine("Your Order:");
            Console.WriteLine("------------");

            foreach (var item in Order.orders)
            {
                Console.WriteLine(Order.orders.IndexOf(item) + ". " + item.Name + "\t\t\t\t" + item.price + " PHP");
            }

            Console.WriteLine("------------");
            Console.WriteLine("Would you like to remove any items from the order? (Y/N)");

            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.WriteLine("Enter the NUMBER of the item you want to remove: ");
                int itemNum = int.Parse(Console.ReadLine());

                Order.orders.RemoveAt(itemNum);
                Console.WriteLine("Order Deleted.");
                ConfirmOrder();

            }
            else if (choice.ToLower() == "n")
            {
                GenerateOrderNumber();
                Payment.ProcessCashPayment(Order);
            }
            else
            {
                Prompts.CenterPrompt(Prompts.invalidInput);
                Prompts.ContinueKey();
                ConfirmOrder();
            }
        }
        //Method to AUTO-GENERATE ORDER NUMBER and Get DATE
        internal void GenerateOrderNumber() //Method to Get Order Number
        {
            Random rnd = new();
            Order.OrderNumber = rnd.Next(10, 999); //Randomly Generated 6 digit number
            Order.date = DateTime.Now;
            TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Order.date, "Singapore Standard Time");
        }
    }
}
