using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BEFORE: Multiple Instances Problem ===\n");
            DemoBefore();

            Console.WriteLine("\n\n=== AFTER: Singleton Pattern Solution ===\n");
            DemoAfter();

            Console.WriteLine("\n\n=== Modern Approach with Lazy<T> ===\n");
            DemoModernApproach();
        }

        static void DemoBefore()
        {
            var userService = new Before.UserService();
            var orderService = new Before.OrderService();

            userService.CreateUser("Alice");
            userService.CreateUser("Bob");
            
            orderService.CreateOrder(101);
            orderService.CreateOrder(102);

            Console.WriteLine("\n❌ Problem: Two separate logger instances created!");
            Console.WriteLine("❌ Logs are not centralized!");
        }

        static void DemoAfter()
        {
            var userService = new After.UserService();
            var orderService = new After.OrderService();

            userService.CreateUser("Alice");
            userService.CreateUser("Bob");
            
            orderService.CreateOrder(101);
            orderService.CreateOrder(102);

            // All logs are in the same instance
            After.ApplicationLogger.GetInstance().ShowLogs();

            // Verify it's the same instance
            var logger1 = After.ApplicationLogger.GetInstance();
            var logger2 = After.ApplicationLogger.GetInstance();
            Console.WriteLine($"\n✅ Same instance? {ReferenceEquals(logger1, logger2)}");
        }

        static void DemoModernApproach()
        {
            After.ModernApplicationLogger.Instance.Log("First log");
            After.ModernApplicationLogger.Instance.Log("Second log");
            After.ModernApplicationLogger.Instance.Log("Third log");

            After.ModernApplicationLogger.Instance.ShowLogs();

            // Verify it's the same instance
            var logger1 = After.ModernApplicationLogger.Instance;
            var logger2 = After.ModernApplicationLogger.Instance;
            Console.WriteLine($"\n✅ Same instance? {ReferenceEquals(logger1, logger2)}");
        }
    }
}
