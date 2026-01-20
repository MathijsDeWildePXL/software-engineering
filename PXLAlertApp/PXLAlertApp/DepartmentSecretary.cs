namespace PXLAlertApp;

public class DepartmentSecretary
{
    private List<PXLAlertMessage> _messages = new List<PXLAlertMessage>();
    private int _currentId = 0;

    // ToDo: this coupling is too tight, remove these lists and use a pattern instead
    private List<Student> _students = new List<Student>();
    private List<PublicityScreen> _screens = new List<PublicityScreen>();


    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void AddScreen(PublicityScreen screen)
    {
        _screens.Add(screen);
    }

    public void AnnounceRosterChange(string content)
    {
        _currentId++;
        var message = new PXLAlertMessage(_currentId, Severity.Low, content, DateTime.Now);
        _messages.Add(message);

        // this is not very flexible and too tightly coupled
        foreach (var student in _students)
        {
            student.SendViaWhatsApp(message);
        }

        foreach (var screen in _screens)
        {
            screen.Display(message);
        }
    }

    public void AnnounceFireAlarm(string content)
    {
        _currentId++;
        var message = new PXLAlertMessage(_currentId, Severity.High, content, DateTime.Now);
        _messages.Add(message);

        // this is not very flexible and too tightly coupled
        foreach (var student in _students)
        {
            student.SendViaWhatsApp(message);
        }

        foreach (var screen in _screens)
        {
            screen.Display(message);
        }
    }
}

// NEW 
public class ObserverDepartmentSecretary : ISubject
{
    private int _currentId;

    private readonly List<IObserver> _observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string message, Severity severity)
    {
        _currentId++;
        PXLAlertMessage alertMessage = new PXLAlertMessage(_currentId, severity, message, DateTime.Now);
        foreach (var observer in _observers)
        {
            observer.Update(alertMessage);
        }
    }
}