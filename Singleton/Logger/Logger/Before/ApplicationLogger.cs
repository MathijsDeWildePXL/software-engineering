using System;
using System.Collections.Generic;

namespace Logger.Before
{
    // PROBLEM: Multiple instances can be created
    // - Inconsistent logging
    // - Multiple file handles
    // - Resource waste
    
    public class ApplicationLogger
    {
        private List<string> _logs = new List<string>();

        public ApplicationLogger()
        {
            Console.WriteLine("Creating new logger instance...");
        }

        public void Log(string message)
        {
            var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            _logs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void ShowLogs()
        {
            Console.WriteLine($"\nTotal logs in this instance: {_logs.Count}");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }
    }

    // Usage problem demonstration
    public class UserService
    {
        private ApplicationLogger _logger = new ApplicationLogger();

        public void CreateUser(string username)
        {
            _logger.Log($"Creating user: {username}");
        }
    }

    public class OrderService
    {
        private ApplicationLogger _logger = new ApplicationLogger();

        public void CreateOrder(int orderId)
        {
            _logger.Log($"Creating order: {orderId}");
        }
    }

    // Problem: Each service has its own logger instance!
    // Logs are not centralized
    // Multiple instances waste memory
}
