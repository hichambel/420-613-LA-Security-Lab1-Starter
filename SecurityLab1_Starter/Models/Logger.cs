using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;

namespace SecurityLab1_Starter.Models
{
    public class Logger
    {

        public void LogToFile(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public void LogToEventViewer(EventLogEntryType type, String text)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {

                eventLog.Source = "Application";
                eventLog.WriteEntry(text, type, 101, 1);
            }

        }

    }
}