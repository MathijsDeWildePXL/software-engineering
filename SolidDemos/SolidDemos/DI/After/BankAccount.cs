namespace SolidDemos.DI.After
{
    public class BankAccount : ITransferSource, ITransferDestination
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
