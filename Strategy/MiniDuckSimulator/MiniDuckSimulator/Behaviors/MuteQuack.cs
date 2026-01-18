using MiniDuckSimulator.Behaviors.Abstractions;

namespace MiniDuckSimulator.Behaviors;

public class MuteQuack : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("<< Silence >>");
    }
}
