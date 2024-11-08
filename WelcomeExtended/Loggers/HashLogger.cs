using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;
        public HashLogger(string name)
        {
            this._name = name;
            this._logMessages = new ConcurrentDictionary<int, string>();

        }

        public IDisposable? BeginScope<TState>(TState state)
        {

            return null; 
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;  
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}"); Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;

        }

        public void PrintAllMessages()
        {
            foreach (var logEntry in _logMessages)
            {
                Console.WriteLine($"EventId: {logEntry.Key}, Message: {logEntry.Value}");
            }
        }
        public void PrintMessageByEventId(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out var message))
            {
                Console.WriteLine($"EventId: {eventId}, Message: {message}");
            }
            else
            {
                Console.WriteLine($"No log message found for EventId: {eventId}");
            }
        }
        public bool DeleteMessageByEventId(int eventId)
        {
            return _logMessages.TryRemove(eventId, out _);
        }
    }
}
    }
}
