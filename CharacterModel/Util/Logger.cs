using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterModel.Util
{
    public static class Logger
    {
        //May need admin rights for default value  
        private static string logFileName = Directory.GetCurrentDirectory();

        public static void SetLogDirectory(string directory)
        {
            logFileName = directory + @"\BattleLog.txt";
        }
        public static void CreateNewLogFile()
        {
            using (FileStream fs = File.Create(logFileName));
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
                CreateNewLogFile();
            }
        }
    }
}
