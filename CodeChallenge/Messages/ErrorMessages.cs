using System;

namespace CodeChallenge
{
    public class ErrorMessages
    {

        public static void ApiSettingError()
        {
            string message = "Error on Setting / API";
            Console.WriteLine(message);
            Logger.WriteLog(message);

        }

        public static void InvaliZipCode()
        {
            string message = "Invalid zipcode";
            Console.WriteLine(message);
            Logger.WriteLog(message);
        }

        public static void NullData(string zipcode)
        {
            string message = string.Format("No data gathered from zipcode: {0}", zipcode);
            Console.WriteLine(message);
            Logger.WriteLog(message);
        }
    }
}
