using PXLAlertApp;

namespace PXLAlertApp
{
    public class PublicityScreen
    {
        private int _id;

        public PublicityScreen(int id)
        {
            _id = id;
        }

        public void Display(PXLAlertMessage alertMessage)
        {
            Console.WriteLine($"Publicity screen ({_id}) displays an alert: ");
            Console.WriteLine(alertMessage);
        }
    }
}

// NEW
public class ObserverPublicityScreen : IObserver, IDisplayElement
{
    private int _id;

    public ObserverPublicityScreen(int id)
    {
        _id = id;
    }

    public void Update(PXLAlertMessage alertMessage)
    {
        Display(alertMessage);
    }


    public void Display(PXLAlertMessage alertMessage)
    {
        Console.WriteLine($"Publicity screen ({_id}) displays an alert: ");
        Console.WriteLine(alertMessage);
    }
}