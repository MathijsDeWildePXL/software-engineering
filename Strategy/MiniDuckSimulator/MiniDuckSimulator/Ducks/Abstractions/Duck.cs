using MiniDuckSimulator.Behaviors.Abstractions;

namespace MiniDuckSimulator.Ducks.Abstractions;

public abstract class Duck
{
    public IFlyBehavior? FlyBehavior { get; set; }
    public IQuackBehavior? QuackBehavior { get; set; }

    protected Duck()
    {
    }

    public abstract void Display();

    public void PerformFly()
    {
        FlyBehavior?.Fly();
    }

    public void PerformQuack()
    {
        QuackBehavior?.Quack();
    }

    public void Swim()
    {
        Console.WriteLine("All ducks float, even decoys!");
    }
}
