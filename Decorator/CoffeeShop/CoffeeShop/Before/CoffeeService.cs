using System;

namespace CoffeeShop.Before
{
    // PROBLEM: Class explosion - need a class for every combination
    // Simple Coffee, Coffee with Milk, Coffee with Sugar, Coffee with Milk and Sugar, etc.
    
    public abstract class Coffee
    {
        public abstract string GetDescription();
        public abstract decimal GetCost();
    }

    public class SimpleCoffee : Coffee
    {
        public override string GetDescription()
        {
            return "Simple Coffee";
        }

        public override decimal GetCost()
        {
            return 2.00m;
        }
    }

    // Need separate classes for each combination!
    public class CoffeeWithMilk : Coffee
    {
        public override string GetDescription()
        {
            return "Coffee with Milk";
        }

        public override decimal GetCost()
        {
            return 2.50m;
        }
    }

    public class CoffeeWithSugar : Coffee
    {
        public override string GetDescription()
        {
            return "Coffee with Sugar";
        }

        public override decimal GetCost()
        {
            return 2.25m;
        }
    }

    public class CoffeeWithMilkAndSugar : Coffee
    {
        public override string GetDescription()
        {
            return "Coffee with Milk and Sugar";
        }

        public override decimal GetCost()
        {
            return 2.75m;
        }
    }

    // What if we add whipped cream? Caramel? Vanilla?
    // We'd need exponentially more classes!
    // CoffeeWithMilkAndWhippedCream
    // CoffeeWithSugarAndWhippedCream
    // CoffeeWithMilkSugarAndWhippedCream
    // etc...
}
