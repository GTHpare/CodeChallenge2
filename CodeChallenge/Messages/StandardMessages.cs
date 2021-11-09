using System;
using WeatherStack;
using AppSetting;


namespace CodeChallenge
{
    public class StandardMessages
    {
      
       
        public static bool TryAgainMessage()
        {
            bool again;
            Console.WriteLine("Should you try again: yes/ enter any text to exit");
            string againStr = Console.ReadLine();
            if (againStr == "Yes" || againStr == "yes")
            {
                again = true;

                Logger.WriteLog("Try again: Yes");

            }
            else
            {
                again = false;

                Logger.WriteLog("Try again: No");

            }
            return again;
        }
        public static void WelcomeMessage()
        {
            Console.WriteLine("What is your zipcode:(UK/Canada/US ZIP code only)");

           
        }
        public static string GetShowZipcode()
        {
            string zipcode = Console.ReadLine();
            Logger.WriteLog(string.Format("zipcode: {0}", zipcode));

            return zipcode;

        }
        public static void ShowLocationMessage(WeatherObject weather)
        {
            string message  = String.Format("Location: Country: {0} Name: {1} Local Time: {2}", weather.location.country, weather.location.name, weather.location.localtime);
            Console.WriteLine(message);
            Logger.WriteLog(message);


        }


    }
}
