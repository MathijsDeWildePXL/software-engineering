namespace SolidDemos.ISP_DI.After
{
    public class Emailer
    {
        public void SendMessage(IEmailable target, string subject, string body)
        {
            // Code to send email, using target's email address and name
        }
    }
}
