namespace parking_system_c
{
    internal class Payment
    {
        public static double TotalAmount(int a)
        {
            double res = 0;
            if (a <= 15) res = 0;
            else res = (a - 15) * 2.5;
            return res;
        }
    }
}
