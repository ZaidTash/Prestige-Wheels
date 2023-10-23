using Prestige_Wheels.Enums;

namespace Prestige_Wheels.Models.Cars
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public CarType CarType { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }
}
