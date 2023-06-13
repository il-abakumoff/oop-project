using System;

namespace parking_system_c
{
    internal class Randomizer
    {
        static Random rand = new Random();

        readonly static string[] letter = { "A", "B", "E", "K", "M", "H", "O", "P", "C", "T", "Y", "X" };
        readonly static string[] color = { "Красный", "Желтый", "Зеленый", "Белый", "Коричневый", "Фиолетовый", "Розовый" };
        readonly static string[] type = { "Седан", "Хэтчбек", "Минивэн", "Автобус", "Пикап", "Универсал" };

        public static int IntegerNum()
        {
            int num = rand.Next(1, 1000);
            return num;
        }
        public static string NumberPlate()
        {
            int n = IntegerNum();

            string num;

            if (n < 10) num = "00" + n;
            else if (n < 100 & n >= 10) num = "0" + n;
            else num = n + "";

            return letter[rand.Next(letter.Length)] + num + letter[rand.Next(letter.Length)] + letter[rand.Next(letter.Length)];
        }
        public static string CarColor()
        {
            int item = rand.Next(color.Length);
            return color[item];
        }
        public static string CarType()
        {
            int item = rand.Next(type.Length);
            return type[item];
        }
    }
}
