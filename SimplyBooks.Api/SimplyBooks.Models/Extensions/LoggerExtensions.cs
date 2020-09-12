using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace SimplyBooks.Models.Extensions
{
    public static class LoggerExtensions
    {
        private static EventId GenerateEventId()
        {
            var id = new Random((int)DateTime.UtcNow.ToBinary()).Next(0, 100000);
            return new EventId(id);
        }

        private static SimplyBooksLogEvent BuildLogEvent(EventId eventId, string message)
        {
            return new SimplyBooksLogEvent(message)
                .AddProp("eventId", eventId);
        }

        public static EventId LogErrorWithEventId(this ILogger logger, Exception exception)
        {
            var eventId = GenerateEventId();
            logger.Log(LogLevel.Error, eventId, BuildLogEvent(eventId, exception.Message), exception, SimplyBooksLogEvent.Formatter);
            return eventId;
        }
    }

    internal class SimplyBooksLogEvent
    {
        private List<KeyValuePair<string, object>> Properties { get; } = new List<KeyValuePair<string, object>>();
        internal string Message { get; set; }

        internal SimplyBooksLogEvent(string message)
        {
            Message = message;
        }

        internal SimplyBooksLogEvent AddProp(string name, object value)
        {
            Properties.Add(new KeyValuePair<string, object>(name, value));
            return this;
        }

        internal static Func<SimplyBooksLogEvent, Exception, string> Formatter { get; } = (l, e) => l.Message;
    }
}
