using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Week3_DSA
{
    internal class items
    {
        internal string Name { get; set; }
        internal decimal price { get; set; }
    }
    internal class Transaction
    {
        internal int OrderNumber;
        public string Name;
        internal DateTime date;
        internal List<items> orders = new List<items>();
        internal decimal Total;
        public int refNum;
    }
    internal class TransactionRecord
    {
        List<Transaction> Record = new List<Transaction>();

        internal void AddNew(Transaction NewTrans)
        {
            Record.Add(NewTrans);
        }
        internal void ShowAll()
        {
            foreach (Transaction Trans in Record) 
            {
                Console.WriteLine("Client Name: " + Trans.Name + " Referrence Number: " + Trans.refNum);
            }
        }
    }

}
