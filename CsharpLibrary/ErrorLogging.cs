using System.Diagnostics;
using System;

namespace CsharpLibrary
{
    public class ErrorLogging : IErrorLogging
    {
        string SourceName = "MyDevelopments";

        /// <summary>
        /// Default constructor
        /// </summary>
        public ErrorLogging()
        {
            //Do nothing
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="logName">Log name</param>
        /// <param name="sourceName">Source of the event</param>
        public ErrorLogging(string logName, string sourceName)
        {
            if (!EventLog.Exists(logName))
            {
                EventLog.CreateEventSource(logName, sourceName);
            }
            SourceName = sourceName;
        }

        public void Error(string message)
        {
            EventLog.WriteEntry(this.SourceName, message, EventLogEntryType.Error);
        }

        public void Exception(Exception ex)
        {
            EventLog.WriteEntry(this.SourceName, ex.Message, EventLogEntryType.Error);
        }

        public void Warning(string message)
        {
            EventLog.WriteEntry(this.SourceName, message, EventLogEntryType.Warning);
        }

        public void Information(string message)
        {
            EventLog.WriteEntry(this.SourceName, message, EventLogEntryType.Information);
        }

        public void SuccessAudit(string message)
        {
            EventLog.WriteEntry(this.SourceName, message, EventLogEntryType.SuccessAudit);
        }

        public void FailureAudit(string message)
        {
            EventLog.WriteEntry(this.SourceName, message, EventLogEntryType.FailureAudit);
        }
    }

    public interface IErrorLogging
    {
        void Error(string message);
        void Exception(Exception ex);
        void Warning(string message);
        void Information(string message);
        void SuccessAudit(string message);
        void FailureAudit(string message);
    }
}
