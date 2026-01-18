using MiniDuckSimulator.Behaviors.Abstractions;

namespace MiniDuckSimulator.Behaviors;

public class Squeak : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Squeak");
    }
}
