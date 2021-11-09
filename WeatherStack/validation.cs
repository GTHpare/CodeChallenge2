using System;
using System.Text.RegularExpressions;


namespace WeatherStack
{
    public class Validation
    {
        public static bool ValidateZipcode(string zipcode)
        {
          
            if (!Regex.Match(zipcode, @"^\d{5}$").Success)
            {
                return false;
            }
            return true;
        }

       
    }
}
