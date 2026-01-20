namespace PXLAlertApp;

public class Student
{
    public Student(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public void SendViaWhatsApp(PXLAlertMessage alertMessage)
    {
        Console.WriteLine($"Student ({Name}) received an alert via WhatsApp: ");
        Console.WriteLine(alertMessage);
    }
}

// NEW 
public class ObserverStudent : IObserver
{
    public ObserverStudent(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public void Update(PXLAlertMessage alertMessage)
    {
        Console.WriteLine($"Student ({Name}) received an alert via WhatsApp: ");
        Console.WriteLine(alertMessage);
    }
}