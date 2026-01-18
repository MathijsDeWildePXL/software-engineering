using System;

namespace SolidDemos.OC.After
{
    public class ConsoleLogger : IMessageLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
