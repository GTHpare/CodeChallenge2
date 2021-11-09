using AppSetting;
using System;
using System.IO;

namespace CodeChallenge
{
    public static class Logger
    {
      
        public static void WriteLog(string Message)
        {
            AppSettingsHandler appHandler = new AppSettingsHandler("appSettings.json");
            AppSettings appSettings = appHandler.GetAppSettings();
            string logPath = appSettings.Logs.LogPath;


            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {Message}");
            }
        }


    }
}
