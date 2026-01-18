using MiniDuckSimulator.Behaviors.Abstractions;

namespace MiniDuckSimulator.Behaviors;

public class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I can't fly");
    }
}
