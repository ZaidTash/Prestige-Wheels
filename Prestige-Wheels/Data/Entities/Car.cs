using Prestige_Wheels.Enums;

namespace Prestige_Wheels.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }   
        public CarType CarType { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

    }
}
