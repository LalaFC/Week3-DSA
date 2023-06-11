using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_DSA
{
    internal class DisplayReceipt
    {
        internal void Print(Transaction Order)
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
            receipt = receipt.Append(" Orders: ");
            foreach (items item in Order.orders)
            {
                receipt = receipt.Append("\t" + item.Name + "\t\t" + item.price + " PHP");
            }
            receipt = receipt.Append(" Total Amount: " + Order.Total);
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
    public static class PrintExtensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            return new List<T>(array) { item }.ToArray();
        }
    }
}
