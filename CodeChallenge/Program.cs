using System;
using System.Threading.Tasks;
using WeatherStack;


namespace CodeChallenge
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            bool again = true;
            while (again)
            {
                await CodeChallenge();
                again = StandardMessages.TryAgainMessage();


            }
        }
        private static async Task CodeChallenge()
        {
            StandardMessages.WelcomeMessage();

            string zipcode = StandardMessages.GetShowZipcode();
            bool isValidZip = Validation.ValidateZipcode(zipcode);
            if (isValidZip)
            {
                try
                {
                    WeatherObject weather = new WeatherObject();
                    weather = await WeatherForecast.GetCurrentWeatherFromZipCode(zipcode);
                    if (weather.location != null)
                    {
                        StandardMessages.ShowLocationMessage(weather);

                        WeatherMessages.ShowResultRaining(weather);
                        WeatherMessages.ShowResultSunscreen(weather);
                        WeatherMessages.ShowResultKite(weather);

                    }
                    else
                    {
                        ErrorMessages.NullData(zipcode);
                    }

                }
                catch
                {
                    ErrorMessages.ApiSettingError();
                }

            }
            else
            {
                ErrorMessages.InvaliZipCode();
            }




        }
    }
}
