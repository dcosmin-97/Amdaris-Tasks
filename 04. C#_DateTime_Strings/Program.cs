using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings_Dates
{
    public class Program
    {
        public static void Main()
        {

            string currentVersion = "2.0.0";
            string newVersion = "2.0.1";

            CheckIfUpdateAvailable(newVersion, currentVersion);

            DateTime lastRewardTime = DateTime.Now - new TimeSpan(24, 10, 10);
            DateTime currentTime = DateTime.Now;

            CheckDailyReward(24, lastRewardTime, currentTime);

            SplitJoin("ana are mere");

            Dates();

            ShowCurrency("ro-RO", 25.5f);
        }


        public static bool CheckIfUpdateAvailable(string newVersion, string currentVersion)
        {
            if (!string.IsNullOrEmpty(newVersion))
            {
                if (newVersion.Length >= 3)
                {
                    int currentVersionInt = Int32.Parse(Filter(currentVersion, '.'));
                    int newVersionInt = Int32.Parse(Filter(newVersion, '.'));

                    if (newVersionInt > currentVersionInt)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public static string Filter(string str, char charToRemove)
        {
            str = str.Replace(charToRemove.ToString(), String.Empty);
            return str;
        }


        public static int HoursFunction(DateTime from, DateTime to)
        {
            if (from > to)
            {
                throw new ArgumentException("from must not be after to");
            }

            // Trim to hours
            DateTime fromTrimmed = new DateTime(from.Year, from.Month, from.Day, from.Hour, from.Minute, 0);
            DateTime toTrimmed = new DateTime(to.Year, to.Month, to.Day, to.Hour, to.Minute, 0);

            int hours = (int)(toTrimmed - fromTrimmed).TotalHours;

            return hours;
        }
        public static bool CheckDailyReward(int minHours, DateTime from, DateTime to)
        {
            if (HoursFunction(from, to) == minHours)
            {
                Console.WriteLine("Receive reward");
                return true;
            }

            return false;
        }

        public static void SplitJoin(string something)
        {
            var final = string.Join(" - ", something.Split(" "));
            Console.WriteLine(final);
        }


        public static void Dates()
        {
            try
            {
                DateTimeOffset offset = new DateTimeOffset(2020, 6, 1, 7, 55, 0, new TimeSpan(-5, 0, 0));

                TimeSpan elapsedTime = new TimeSpan(10, 0, 0);

                DateTimeOffset value = offset.Add(elapsedTime);

                // Display the time
                Console.WriteLine("DateTimeOffset is {0}", value);
            }

            catch (ArgumentOutOfRangeException e)
            {
                Console.Write("Exception Thrown: ");
                Console.Write("{0}", e.GetType(), e.Message);
            }
        }
        
        public static void ShowCurrency(string zone, float price)
        {
            var zoneSplit = zone.Split('-');

            if (zoneSplit.Length == 2)
            {
                Console.WriteLine($"The price is - { price.ToString("C",new CultureInfo(zone)) } and it is available in - {zone} region");
            }
        }
    }
}
