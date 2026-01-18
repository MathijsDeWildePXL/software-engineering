using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemos.OC.After
{
    public class Logger
    {
        private IMessageLogger _messageLogger;

        public Logger(IMessageLogger messageLogger)
        {
            _messageLogger = messageLogger;
        }

        public void Log(string message)
        {
            _messageLogger.Log(message);
        }
    }
}
