using MiniDuckSimulator.Behaviors.Abstractions;

namespace MiniDuckSimulator.Behaviors;

public class Quack : IQuackBehavior
{
    void IQuackBehavior.Quack()
    {
        Console.WriteLine("Quack");
    }
}
