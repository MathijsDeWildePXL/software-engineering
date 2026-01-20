namespace PXLAlertApp;

public class Program
{
    public static void NotMain(string[] args)
    {
        // this MUST be the same, don't change this
        var pxlDigital = new DepartmentSecretary();

        // TODO: you may change this
        var studentPiet = new Student("Piet Pienter");
        pxlDigital.AddStudent(studentPiet);
        var studentBert = new Student("Bert Bibber");
        pxlDigital.AddStudent(studentBert);
        var screenBuildingB = new PublicityScreen(66);
        pxlDigital.AddScreen(screenBuildingB);

        // this MUST be te same, don't change this
        pxlDigital.AnnounceRosterChange("RosterChange 1");
        pxlDigital.AnnounceRosterChange("RosterChange 2");
        pxlDigital.AnnounceFireAlarm("FireAlarm 1");
    }
}

// NEW 
public class OberverPatternProgram
{
    public static void Main(string[] args)
    {
        // this MUST be the same, don't change this
        var pxlDigital = new ObserverDepartmentSecretary();

        // TODO: you may change this
        var studentPiet = new ObserverStudent("Piet Pienter");
        var studentBert = new ObserverStudent("Bert Bibber");
        var screenBuildingB = new ObserverPublicityScreen(66);
        pxlDigital.RegisterObserver(studentBert);
        pxlDigital.RegisterObserver(studentPiet);
        pxlDigital.RegisterObserver(screenBuildingB);

        // this MUST be te same, don't change this
        pxlDigital.NotifyObservers("RosterChange 1", Severity.Low);
        pxlDigital.NotifyObservers("RosterChange 2", Severity.Low);
        pxlDigital.NotifyObservers("FireAlarm 1", Severity.High);
    }
}