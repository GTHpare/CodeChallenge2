using AppSetting;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace WeatherStack
{
    public class WeatherForecast
    {
        public static async Task<WeatherObject> GetCurrentWeatherFromZipCode(string zipcode)
        {
            HttpClient http = new HttpClient();

            AppSettingsHandler appHandler = new AppSettingsHandler("appSettings.json");
            AppSettings appSettings = appHandler.GetAppSettings();


            string key = appSettings.APISettings.API_Key;
            string api_url = appSettings.APISettings.API_URL;
            string units = appSettings.APISettings.Units;
            WeatherObject data = new WeatherObject();
            if (key != "Not Found")
            {
                string url = string.Format(api_url, key, zipcode, units);
                HttpResponseMessage response = await http.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherObject));

                MemoryStream memorystream = new MemoryStream(Encoding.UTF8.GetBytes(result));
                data = (WeatherObject)serializer.ReadObject(memorystream);

            }

            return data;
        }
        public static bool isRaining(string wethearCode)
        {
            bool isRaining = false;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\wwoConditionCodes.xml");
            XmlDocument myDoc = new XmlDocument();

            myDoc.Load(path);

            XmlElement root = myDoc.DocumentElement;

            foreach (XmlNode node in root.SelectNodes("condition"))
            {
                XmlNode child = node.SelectSingleNode("code");
                if (child != null && child.InnerText == wethearCode)
                {

                    XmlNode child_description = node.SelectSingleNode("description");
                    if (child_description.InnerText.Contains("rain"))
                    {
                        return true;
                    }
                }
            }
            return isRaining;
        }
    }


}
