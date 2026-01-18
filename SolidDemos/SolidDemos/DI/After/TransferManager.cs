namespace SolidDemos.DI.After
{
    public class TransferManager
    {
        public ITransferSource Source { get; set; }

        public ITransferDestination Destination { get; set; }

        public decimal Value { get; set; }

        public void Transfer()
        {
            Source.RemoveFunds(Value);
            Destination.AddFunds(Value);
        }
    }
}
