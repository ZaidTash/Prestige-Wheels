namespace Prestige_Wheels.Data.Entities
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Year { get; set; }

        public List<Car> Cars { get; set; }
    }
}
