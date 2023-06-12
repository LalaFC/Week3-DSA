﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_DSA
{
    internal class DisplayReceipt
    {
        internal void Print(Transaction Order, decimal GivenAmount)
        {
            string folderLocation = @"C:\temp\";
            string fileName = "receipt" + Order.refNum + ".txt";
            string fullPath = folderLocation + fileName;

            // An array of strings
            string[] receipt =
                {
                            "**************************************",
                            "                                      ",
                            "          A2 Psych Ward Cafe          ",
                            "           Official Receipt           ",
                            "                                      ",
                            "**************************************",
                            "                                      "
             };
            receipt = receipt.Append(" ORDER #: " + Order.OrderNumber);
            receipt = receipt.Append(" Client Name: " + Order.Name);
            receipt = receipt.Append(" Date: " + Order.date);
            receipt = receipt.Append("                                      ");
            receipt = receipt.Append(" Orders: ");
            foreach (items item in Order.orders)
            {
                receipt = receipt.Append("\t" + item.Name + "\t\t" + item.price + " PHP");
            }
            receipt = receipt.Append("                                      ");
            receipt = receipt.Append(" Total Amount: " + Order.Total);
            receipt = receipt.Append(" Amount Received: " + GivenAmount);
            receipt = receipt.Append(" Change: " + (GivenAmount-Order.Total));
            receipt = receipt.Append("                                      ");
            receipt = receipt.Append(" Thank you for buying @ A2 Psych Ward Cafe. Please come again. ");
            receipt = receipt.Append(" Ref #: " + Order.refNum);
            //Add Other Strings Here

            File.WriteAllLines(fullPath, receipt);

            var fileToOpen = fullPath;
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = fileToOpen
            };

            process.Start();
            process.WaitForExit();
            Console.Write("Would you like to order again? ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Menu menu = new();
                menu.ShowMenu();
            }
            else if (choice.ToLower() == "n")
            {
                Login restart = new Login();
                restart.LoginScreen();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
    public static class PrintExtensions //Method to add 1 Line in Receipt
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            return new List<T>(array) { item }.ToArray();
        }
    }
}
