using System;

namespace PizzaStoreComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE: Direct Instantiation Problem ===\n");
            DemoBefore();

            Console.WriteLine("\n\n=== AFTER: Factory Method Pattern Solution ===\n");
            DemoAfter();
        }

        static void DemoBefore()
        {
            var pizzaStore = new Before.PizzaStore();

            Console.WriteLine("--- Ordering Cheese Pizza ---");
            var pizza1 = pizzaStore.OrderPizza("cheese");
            Console.WriteLine($"Ordered: {pizza1.Name}\n");

            Console.WriteLine("--- Ordering Pepperoni Pizza ---");
            var pizza2 = pizzaStore.OrderPizza("pepperoni");
            Console.WriteLine($"Ordered: {pizza2.Name}\n");

            Console.WriteLine("❌ Problem: All pizzas are the same style!");
            Console.WriteLine("❌ Can't easily add NY, Chicago, or California styles!");
            Console.WriteLine("❌ Must modify PizzaStore to add new types!");
        }

        static void DemoAfter()
        {
            After.PizzaStore nyStore = new After.NYPizzaStore();
            After.PizzaStore chicagoStore = new After.ChicagoPizzaStore();

            Console.WriteLine("--- Ordering from NY Store ---");
            var pizza1 = nyStore.OrderPizza("cheese");
            Console.WriteLine($"Ethan ordered: {pizza1.Name}\n");

            Console.WriteLine("--- Ordering from Chicago Store ---");
            var pizza2 = chicagoStore.OrderPizza("cheese");
            Console.WriteLine($"Joel ordered: {pizza2.Name}\n");

            Console.WriteLine("--- Ordering Pepperoni from Both ---");
            var pizza3 = nyStore.OrderPizza("pepperoni");
            Console.WriteLine($"NY Pepperoni: {pizza3.Name}\n");

            var pizza4 = chicagoStore.OrderPizza("pepperoni");
            Console.WriteLine($"Chicago Pepperoni: {pizza4.Name}\n");

            Console.WriteLine("✅ Solution: Each store creates its own style!");
            Console.WriteLine("✅ Easy to add new pizza styles (California, Detroit, etc.)!");
            Console.WriteLine("✅ Factory method delegates creation to subclasses!");
            Console.WriteLine("✅ Follows Open/Closed Principle!");
        }
    }
}
