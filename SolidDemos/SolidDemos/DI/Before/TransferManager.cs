namespace SolidDemos.DI.Before
{
    public class TransferManager
    {
        public BankAccount Source { get; set; }

        public BankAccount Destination { get; set; }

        public decimal Value { get; set; }

        public void Transfer()
        {
            Source.RemoveFunds(Value);
            Destination.AddFunds(Value);
        }
    }
}
