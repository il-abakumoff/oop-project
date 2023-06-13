using System;

namespace parking_system_c
{
    internal class ParkingTicket
    {
        public DateTime EnterDataTime { get; set; }
        public int SpotNumber { get; set; }
        public Car Car { get; set; }

        public ParkingTicket(Car car, DateTime enter, int spot)
        {
            this.SpotNumber = spot;
            this.EnterDataTime = enter;
            this.Car = car;
        }
    }
}
