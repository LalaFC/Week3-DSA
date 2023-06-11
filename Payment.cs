using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_DSA
{
    internal class Payment
    {
        internal void ProcessCashPayment(Transaction Order)
        {
            Order.Name = "User" + Order.OrderNumber;
            Console.WriteLine("Total Amount: " + Order.Total + " PHP");
            Console.WriteLine("Enter the amount you're going to pay: ");
            decimal amountPaid = decimal.Parse(Console.ReadLine());

            if (amountPaid >= Order.Total)
            {
                decimal changeAmount = amountPaid - Order.Total;
                Console.WriteLine($"Payment successful! Change amount: {changeAmount}");
                Order.refNum = GenerateReferenceNumber();
                TransactionRecord record = new TransactionRecord();
                record.AddNew(Order);
                record.ShowAll();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Amount paid is less than the order amount. Please try again.");
                ProcessCashPayment(Order);
            }
        }

        internal int GenerateReferenceNumber()
        {
            Random rnd = new Random();
            int TransactionNumber = rnd.Next(100000, 999999); //Randomly Generated 6 digit number
            return TransactionNumber;
        }

    }
}
