using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Util
{
    internal static class FileLogger
    {
        private static string logFileName = defautDirectory;
        private static readonly string defautDirectory = Directory.GetCurrentDirectory() + @"\BattleLog.txt";

        public static void NewLog(string directory)
        {
            try
            {
                SetLogDirectory(directory);
                CreateNewLogFile();
            }
            catch (DirectoryNotFoundException ex)
            {
                logFileName = defautDirectory;
            }
        }

        private static void SetLogDirectory(string directory)
        {
            logFileName = directory + @"\BattleLog.txt";
        }
        private static void CreateNewLogFile()
        {
            File.Create(logFileName);
        }
        public static void LogMessage(string message)
        {
            using StreamWriter sw = File.AppendText(logFileName);
            sw.WriteLine(message);
        }
    }
}
