namespace parking_system_c
{
    internal class Car
    {
        public string NumberPlate { get; set; }
        public string CarColor { get; set; }
        public string CarType { get; set; }
    
        public Car(string numberPlate, string carColor, string carType)
        {
            this.NumberPlate = numberPlate;
            this.CarColor = carColor;
            this.CarType = carType;
        }

        public string GetInfo()
        {
            return CarColor + " " + CarType + ", номер автомобиля: " + NumberPlate;
        }
    }
}
