// Code based on: https://github.com/d0pare/design-patterns
using MiniDuckSimulator.Ducks;

MallardDuck mallard = new MallardDuck();
DecoyDuck decoy = new DecoyDuck();

mallard.PerformQuack();
mallard.PerformFly();

decoy.PerformQuack();
decoy.PerformFly();