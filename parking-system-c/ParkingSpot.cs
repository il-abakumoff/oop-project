namespace parking_system_c
{
    internal class ParkingSpot
    {
        public static int GetAvailableSpot(ParkingTicket[] list)
        {
            int freeSpot = -1;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == null)
                {
                    freeSpot = i;
                    break;
                }
            }
            return freeSpot;
        }

        public static bool CheckCarOnPark(ParkingTicket[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
