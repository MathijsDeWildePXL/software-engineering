namespace SolidDemos.ISP.After
{
    public class AllInOnePrinter : IPrinter, IScanner, IEmail
    {
        public void SendEmail()
        {
            // EMAIL DOCUMENT
        }

        public void Print()
        {
            // PRINT DOCUMENT
        }

        public void Scan()
        {
            // SCAN DOCUMENT
        }
    }
}
