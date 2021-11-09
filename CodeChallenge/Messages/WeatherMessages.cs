using System;
using WeatherStack;
namespace CodeChallenge
{
    public class WeatherMessages
    {
        public static void ShowResultRaining(WeatherObject weather)
        {
            Console.WriteLine("Should I go outside?");
            bool isRaining = WeatherForecast.isRaining(weather.current.weather_code.ToString());
            if (isRaining)
            {
                string message = "No, its raining";
                Console.WriteLine(message);
                Logger.WriteLog(message);
            }
            else
            {

                string message = "yes, its not raining";
                Console.WriteLine(message);
                Logger.WriteLog(message);
            }


        }

        public static void ShowResultSunscreen(WeatherObject weather)
        {
            Console.WriteLine("Should I wear sunscreen?");
            if (weather.current.uv_index > 3)
            {
                string message = string.Format("yes, UV Index is {0}", weather.current.uv_index);
                Console.WriteLine(message);
                Logger.WriteLog(message);
            }
            else
            {
                string message = string.Format("no, UV Index is only {0}", weather.current.uv_index);
                Console.WriteLine(message);
                Logger.WriteLog(message);
            }

        }

        public static void ShowResultKite(WeatherObject weather)
        {
            Console.WriteLine("Can I fly my kite?");
            if (weather.current.wind_speed > 15)
            {
                string message = string.Format("yes, wind speed is {0}", weather.current.wind_speed);
                Console.WriteLine(message);
                Logger.WriteLog(message);
            }
            else
            {
                string message = string.Format("no, wind speed is {0}", weather.current.wind_speed);
                Console.WriteLine(message);
                Logger.WriteLog(message);
            }

        }
    }
}
