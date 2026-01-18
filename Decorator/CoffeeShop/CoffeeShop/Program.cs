using System;

namespace CoffeeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE: Class Explosion Problem ===\n");
            DemoBefore();

            Console.WriteLine("\n=== AFTER: Decorator Pattern Solution ===\n");
            DemoAfter();
        }

        static void DemoBefore()
        {
            // Limited to predefined combinations
            var coffee1 = new Before.SimpleCoffee();
            Console.WriteLine($"{coffee1.GetDescription()} - ${coffee1.GetCost()}");

            var coffee2 = new Before.CoffeeWithMilk();
            Console.WriteLine($"{coffee2.GetDescription()} - ${coffee2.GetCost()}");

            var coffee3 = new Before.CoffeeWithMilkAndSugar();
            Console.WriteLine($"{coffee3.GetDescription()} - ${coffee3.GetCost()}");

            Console.WriteLine("\n❌ Problem: Can't make coffee with milk, sugar, and whipped cream!");
            Console.WriteLine("❌ Would need to create yet another class!");
        }

        static void DemoAfter()
        {
            // Flexible combinations
            After.ICoffee coffee1 = new After.SimpleCoffee();
            Console.WriteLine($"{coffee1.GetDescription()} - ${coffee1.GetCost()}");

            After.ICoffee coffee2 = new After.SimpleCoffee();
            coffee2 = new After.MilkDecorator(coffee2);
            Console.WriteLine($"{coffee2.GetDescription()} - ${coffee2.GetCost()}");

            After.ICoffee coffee3 = new After.SimpleCoffee();
            coffee3 = new After.MilkDecorator(coffee3);
            coffee3 = new After.SugarDecorator(coffee3);
            Console.WriteLine($"{coffee3.GetDescription()} - ${coffee3.GetCost()}");

            // Easy to create any combination!
            After.ICoffee fancyCoffee = new After.SimpleCoffee();
            fancyCoffee = new After.MilkDecorator(fancyCoffee);
            fancyCoffee = new After.SugarDecorator(fancyCoffee);
            fancyCoffee = new After.WhippedCreamDecorator(fancyCoffee);
            fancyCoffee = new After.CaramelDecorator(fancyCoffee);
            Console.WriteLine($"{fancyCoffee.GetDescription()} - ${fancyCoffee.GetCost()}");

            Console.WriteLine("\n✅ Solution: Flexible combinations without class explosion!");
        }
    }
}
