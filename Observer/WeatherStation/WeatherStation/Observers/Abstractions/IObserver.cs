namespace WeatherStation.Observers.Abstractions;

public interface IObserver
{
    void Update(double temperature, double humidity, double pressure);
}