using System;
using System.Linq;

namespace parking_system_c
{
    internal class Util
    {
        public static string TicketText(ParkingTicket[] list)
        {
            string res = "Информация о припаркованных автомобилях:\n\n";
            foreach (var item in list)
            {
                if (item != null)
                {
                    res += "Парковочное место №" + (item.SpotNumber + 1) + ": " + item.Car.GetInfo() + "\n";
                }
            }
            return res;
        }
        public static string ExitText(ParkingTicket pt, DateTime enter, DateTime exit, int total, double amount)
        {
            return "=== Информация о парковке ===\n" +

                "\nНомер автомобиля: " + pt.Car.NumberPlate + 
                "\nЦвет автомобиля: " + pt.Car.CarColor +
                "\nТип автомобиля: " + pt.Car.CarType +

                "\n\nДата парковки: " + enter.ToString("dd/MM/yyyy") +
                "\nВремя парковки: " + enter.ToString("HH:mm:ss") +
                "\nДата выезда: " + exit.ToString("dd/MM/yyyy") +
                "\nВремя выезда: " + exit.ToString("HH:mm:ss") +

                "\n\nПарковочное место №" + (pt.SpotNumber + 1) +
                "\nОбщее время: " + TimeUtil.TotalTimeFormat(total) +
                "\nСумма: " + amount + " руб.\n";
        }
        public static bool CheckNumberFormat(string num)
        {
            string letters = "ABEKMHOPCTYXАВЕКМНОРСТУХ";
            string number = "0123456789";

            if (num.Length == 6)
            {
                for (int i = 0; i < num.Length; i++)
                {
                    if (i >= 1 & i <= 3)
                    {
                        if (!number.Contains(num[i]))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!letters.Contains(num[i]))
                        {
                            return false;
                        }
                    }
                }

            }
            else return false;
            return true;
        }
    }
}
