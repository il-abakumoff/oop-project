using System;

namespace parking_system_c
{
    internal class TimeUtil
    {
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        public static int GetTotalTime(DateTime enter, DateTime exit)
        {
            return Convert.ToInt32(Math.Floor(exit.Subtract(enter).TotalMinutes));
        }

        public static string TotalTimeFormat(int time)
        {
            string res;

            if (time < 60)
            {
                res = time + " мин.";
            }
            else if (time >= 60 & time < 1440)
            {
                int hours = time / 60;
                res = hours + " час. " + (time - hours * 60) + " мин.";
            }
            else
            {
                int days = time / 1440;
                int hours = time - (days * 1440) / 60;

                res = (days) + " дн. " + hours + " час. " + (time - (days * 1440) - (hours * 60)) + " мин ";
            }
            return res;
        }
    }
}
