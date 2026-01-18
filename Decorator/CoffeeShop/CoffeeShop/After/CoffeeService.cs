using System;

namespace CoffeeShop.After
{
    // SOLUTION: Decorator Pattern - dynamically add responsibilities
    
    public interface ICoffee
    {
        string GetDescription();
        decimal GetCost();
    }

    // Base component
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public decimal GetCost()
        {
            return 2.00m;
        }
    }

    // Abstract decorator
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public virtual decimal GetCost()
        {
            return _coffee.GetCost();
        }
    }

    // Concrete decorators
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", with milk";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.50m;
        }
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", with sugar";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.25m;
        }
    }

    public class WhippedCreamDecorator : CoffeeDecorator
    {
        public WhippedCreamDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", with whipped cream";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.75m;
        }
    }

    public class CaramelDecorator : CoffeeDecorator
    {
        public CaramelDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", with caramel";
        }

        public override decimal GetCost()
        {
            return _coffee.GetCost() + 0.60m;
        }
    }

    // Benefits: Can create any combination without class explosion!
    // Easy to add new decorators
    // Follows Open/Closed Principle
}
