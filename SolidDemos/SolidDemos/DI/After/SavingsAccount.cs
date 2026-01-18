using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemos.DI.After
{
    public class SavingsAccount : ITransferDestination
    {
        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public void AddFunds(decimal value)
        {
            Balance += value;
        }
    }
}
