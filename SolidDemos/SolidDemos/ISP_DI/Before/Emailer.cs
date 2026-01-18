namespace SolidDemos.ISP_DI.Before
{
    public class Emailer
    {
        public void SendMessage(IContact contact, string subject, string body)
        {
            // Code to send email, using contact's email address and name
        }
    }
}
