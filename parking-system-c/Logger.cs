using System;
using System.IO;
using System.Text;

namespace parking_system_c
{
    internal class Logger
    {
        private static string path = @"D:\DEVELOPE\ystu\ystu-oop\parking-system-c\log\log.txt";
        public static void Log(string text)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public static string LoggerText(ParkingTicket pt, string action)
        {
            return DateTime.Now.ToString() + ", " + action + ": " + pt.Car.GetInfo() + ", parkspot: " + (pt.SpotNumber + 1) + "\n";
        }
    }
}
