
using Microsoft.Extensions.Configuration;
using System;


namespace AppSetting
{
    public class AppSettingsHandler
    {
        private readonly string _filename;

        public AppSettingsHandler(string filename)
        {

            _filename = filename;
            _ = GetAppSettings();
        }

        public AppSettings GetAppSettings()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile(_filename, false, true)
               .Build();

            return config.GetSection("App").Get<AppSettings>();
        }

    }
}
