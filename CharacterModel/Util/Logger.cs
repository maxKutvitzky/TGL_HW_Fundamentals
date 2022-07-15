using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Util
{
    public static class Logger
    {
        private static string logFileName = Directory.GetCurrentDirectory() + @"\BattleLog.txt";

        public static void SetLogDirectory(string directory)
        {
            logFileName = directory + @"\BattleLog.txt";
        }
        public static void CreateNewLogFile()
        {
            try
            {
                using (FileStream fs = File.Create(logFileName)) ;
            }
            catch (DirectoryNotFoundException ex)
            {
                logFileName = Directory.GetCurrentDirectory() + @"\BattleLog.txt";
            }
        }
        public static void LogMessage(string message)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(logFileName))
                {
                    sw.WriteLine(message);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                logFileName = Directory.GetCurrentDirectory() + @"\BattleLog.txt";
            }
        }
    }
}
