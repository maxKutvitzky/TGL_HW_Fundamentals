using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Util
{
    public static class FileLogger
    {
        private static readonly string logFileName = Directory.GetCurrentDirectory() + @"\BattleLog.txt";
        /// <summary>
        /// Gets log file location
        /// </summary>
        /// <returns>Current log file location</returns>
        public static string GetLogLocation()
        {
            return logFileName;
        }
        /// <summary>
        /// Opening log file as new process
        /// </summary>
        public static void OpenLog()
        {
            Process.Start("notepad.exe", logFileName);
        }
        /// <summary>
        /// Public method for creating new log file
        /// </summary>
        public static void NewLog()
        {
            CreateNewLogFile();
        }
        /// <summary>
        /// Creates new log file in specific directory
        /// </summary>
        private static void CreateNewLogFile()
        {
            if (File.Exists(logFileName))
            {
                File.Delete(logFileName);
                File.Create(logFileName);
            }
            else
            {
                File.Create(logFileName);
            }
        }
        /// <summary>
        /// Appends message to log file 
        /// </summary>
        /// <param name="message">Message for log</param>
        public static void LogMessage(string message)
        {
            using StreamWriter sw = File.AppendText(logFileName);
            sw.WriteLine(message);
        }
    }
}
