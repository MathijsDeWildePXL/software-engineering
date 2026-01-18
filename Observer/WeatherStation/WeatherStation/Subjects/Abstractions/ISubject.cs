using WeatherStation.Observers.Abstractions;

namespace WeatherStation.Subjects.Abstractions;
public interface ISubject
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}