using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemos.DI.Before
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public void AddFunds(decimal value)
        {
            Balance += value;
        }

        public void RemoveFunds(decimal value)
        {
            Balance -= value;
        }
    }
}
