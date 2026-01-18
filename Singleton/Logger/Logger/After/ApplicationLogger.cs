using System;
using System.Collections.Generic;

namespace Logger.After
{
    // SOLUTION: Singleton Pattern - ensure only one instance
    
    public class ApplicationLogger
    {
        private static ApplicationLogger? _instance;
        private static readonly object _lock = new object();
        private List<string> _logs = new List<string>();

        // Private constructor prevents external instantiation
        private ApplicationLogger()
        {
            Console.WriteLine("Creating the single logger instance...");
        }

        // Thread-safe lazy initialization
        public static ApplicationLogger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ApplicationLogger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            _logs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void ShowLogs()
        {
            Console.WriteLine($"\nTotal logs in singleton instance: {_logs.Count}");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }

    // Modern C# approach using Lazy<T>
    public class ModernApplicationLogger
    {
        private static readonly Lazy<ModernApplicationLogger> _instance 
            = new Lazy<ModernApplicationLogger>(() => new ModernApplicationLogger());
        
        private List<string> _logs = new List<string>();

        private ModernApplicationLogger()
        {
            Console.WriteLine("Creating the single logger instance (modern approach)...");
        }

        public static ModernApplicationLogger Instance => _instance.Value;

        public void Log(string message)
        {
            var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            _logs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void ShowLogs()
        {
            Console.WriteLine($"\nTotal logs in singleton instance: {_logs.Count}");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }

    // Usage with singleton
    public class UserService
    {
        public void CreateUser(string username)
        {
            ApplicationLogger.GetInstance().Log($"Creating user: {username}");
        }
    }

    public class OrderService
    {
        public void CreateOrder(int orderId)
        {
            ApplicationLogger.GetInstance().Log($"Creating order: {orderId}");
        }
    }

    // Benefits: 
    // - Single instance shared across application
    // - Centralized logging
    // - Thread-safe
    // - Resource efficient
}
