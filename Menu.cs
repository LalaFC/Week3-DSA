using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Week3_DSA
{
    internal class Menu
    {
        Transaction Order = new Transaction(); //Creates a New Transaction

        Payment Payment = new Payment();

        internal void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the ordering system!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Pizza");
            Console.WriteLine("2. Desserts");
            Console.WriteLine("3. Drinks");
            Console.WriteLine("4. Confirm Order");
            Console.WriteLine("0. Exit");
            Console.WriteLine(" ");
            Console.Write("Input: ");

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
                    Console.WriteLine("Invalid choice. Exiting the program.");
                    break;
            }
        }

        internal void ShowPizzaMenu()
        {
            Console.Clear();
            string[] menuItems = {
        "Pizza Menu",
        "",
        "1. Pepperoni",
        "2. Ham and Cheese",
        "3. Hawaiian",
        "0. Back" 
            
            };
            string prompt = "Enter your choice: ";
            string quantityPrompt = "Enter the quantity: ";
            string anykeyContinue = "Press Any Key to Continue";
            string invalidInput = "Invalid Input. Please Enter a Number";

            int consoleWidth = Console.WindowWidth;

            Console.WriteLine("Pizza Menu");

            foreach (string menuItem in menuItems)
            {
                int leftPadding = (consoleWidth - menuItem.Length) / 2;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(menuItem);
            }

            Console.WriteLine();

            int promptLeftPadding = (consoleWidth - prompt.Length) / 2;
            Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
            Console.Write(prompt);

            int choice;
         
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                int errorLeftPadding = (consoleWidth - invalidInput.Length) / 2;
                Console.SetCursorPosition(errorLeftPadding, Console.CursorTop);
                Console.WriteLine(invalidInput);
               
                Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
                Console.Write(anykeyContinue);
                Console.ReadKey();
                ShowPizzaMenu();

            }

            Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
            Console.Write(quantityPrompt);

            int quantity;

            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                int errorLeftPadding = (consoleWidth - invalidInput.Length) / 2;
                Console.SetCursorPosition(errorLeftPadding, Console.CursorTop);
                Console.WriteLine(invalidInput);

                Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
                Console.Write(anykeyContinue);
                Console.ReadKey();
                ShowPizzaMenu();

            }


            switch (choice)
            {
                case 0:
                    ShowMenu();
                    break;
                case 1:
                    AddToOrder("Pepperoni", quantity, 399);
                    break;
                case 2:
                    AddToOrder("Ham and Cheese", quantity, 399);
                    break;
                case 3:
                    AddToOrder("Hawaiian", quantity, 399);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowPizzaMenu();
                    break;
            }

        }
        internal void ShowDessertMenu()
        {
            Console.Clear();
            string[] menuItems = {
        "Dessert Menu",
        " ",
        "1. Halo - Halo (45 PHP)",
        "2. Ice Cream (25 PHP)",
        "0. Back"

            };
            string prompt = "Enter your choice: ";
            string quantityPrompt = "Enter the quantity: ";
            string anykeyContinue = "Press Any Key to Continue";
            string invalidInput = "Invalid Input. Please Enter a Number";


            int consoleWidth = Console.WindowWidth;

            Console.WriteLine("Pizza Menu");

            foreach (string menuItem in menuItems)
            {
                int leftPadding = (consoleWidth - menuItem.Length) / 2;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(menuItem);
            }

            Console.WriteLine();

            int promptLeftPadding = (consoleWidth - prompt.Length) / 2;
            Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
            Console.Write(prompt);
            
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                int errorLeftPadding = (consoleWidth - invalidInput.Length) / 2;
                Console.SetCursorPosition(errorLeftPadding, Console.CursorTop);
                Console.WriteLine(invalidInput);

                Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
                Console.Write(anykeyContinue);
                Console.ReadKey();
                ShowDessertMenu();
            }

            Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
            Console.Write(quantityPrompt);

            int quantity;

            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                int errorLeftPadding = (consoleWidth - invalidInput.Length) / 2;
                Console.SetCursorPosition(errorLeftPadding, Console.CursorTop);
                Console.WriteLine(invalidInput);

                Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
                Console.Write(anykeyContinue);
                Console.ReadKey();
                ShowDessertMenu();
            }

            switch (choice)
            {
                case 1:
                    AddToOrder("Halo-halo", quantity, 45);
                    break;
                case 2:
                    AddToOrder("Ice Cream", quantity, 25);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        internal void ShowDrinkMenu()
        {
            Console.Clear();
            string[] menuItems = {
        "Drink Menu",
        " ",
        "1. Coke (25 PHP)",
        "2. Sprite (25 PHP)",
        "0. Back"

            };
            string prompt = "Enter your choice: ";
            string quantityPrompt = "Enter the quantity: ";
            string anykeyContinue = "Press Any Key to Continue";
            string invalidInput = "Invalid Input. Please Enter a Number";


            int consoleWidth = Console.WindowWidth;

            Console.WriteLine("Pizza Menu");

            foreach (string menuItem in menuItems)
            {
                int leftPadding = (consoleWidth - menuItem.Length) / 2;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(menuItem);
            }

            Console.WriteLine();

            int promptLeftPadding = (consoleWidth - prompt.Length) / 2;
            Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
            Console.Write(prompt);

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                int errorLeftPadding = (consoleWidth - invalidInput.Length) / 2;
                Console.SetCursorPosition(errorLeftPadding, Console.CursorTop);
                Console.WriteLine(invalidInput);

                Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
                Console.Write(anykeyContinue);
                Console.ReadKey();
                ShowDrinkMenu();
            }

            Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
            Console.Write(quantityPrompt);

            int quantity;

            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                int errorLeftPadding = (consoleWidth - invalidInput.Length) / 2;
                Console.SetCursorPosition(errorLeftPadding, Console.CursorTop);
                Console.WriteLine(invalidInput);

                Console.SetCursorPosition(promptLeftPadding, Console.CursorTop);
                Console.Write(anykeyContinue);
                Console.ReadKey();
                ShowDrinkMenu();
            }


            switch (choice)
            {
                case 1:
                    AddToOrder("Coke", quantity, 25);
                    break;
                case 2:
                    AddToOrder("Sprite", quantity, 25);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting the program.");
                    break;
            }
        }

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
            Console.WriteLine($"{quantity} {itemName}(s) added to your order. \n Press Any Key to Continue");
            Console.ReadKey();
            ShowMenu();
        }

        internal void ConfirmOrder()
        {
            Console.WriteLine("Your Order:");
            Console.WriteLine("------------");

            foreach (var item in Order.orders)
            {
                Console.WriteLine(Order.orders.IndexOf(item) + ". " + item.Name + "\t\t" + item.price + " PHP");
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
                Console.WriteLine("Invalid choice.");
            }
        }
        internal void GenerateOrderNumber() //Method to Get Order Number
        {
            Random rnd = new Random();
            Order.OrderNumber = rnd.Next(10, 999); //Randomly Generated 6 digit number
            Order.date = DateTime.Now;
            TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Order.date, "Singapore Standard Time");

        }
    }
}
