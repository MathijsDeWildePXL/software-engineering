using System;

namespace SolidDemos.OC.Before
{
    public class Logger
    {
        public void Log(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Console:
                    Console.WriteLine(message);
                    break;

                case LogType.File:
                    // Code to send message to file
                    break;
            }
        }
    }
}
