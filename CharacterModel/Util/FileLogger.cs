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
        private static readonly string defautFileName = Directory.GetCurrentDirectory() + @"\BattleLog.txt";
        private static string logFileName = defautFileName;

        public static string GetLogLocation()
        {
            return logFileName;
        }

        public static void OpenLog()
        {
            Process.Start("notepad.exe", defautFileName);
        }
        public static void NewLog(string directory)
        {
            try
            {
                CreateNewLogFile();
            }
            catch (DirectoryNotFoundException ex)
            {
                logFileName = defautFileName;
            }
        }

        private static void SetLogDirectory(string directory)
        {
            logFileName = directory + @"\BattleLog.txt";
        }
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

        public static void LogMessage(string message)
        {
            using StreamWriter sw = File.AppendText(logFileName);
            sw.WriteLine(message);
        }
    }
}
