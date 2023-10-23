using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prestige_Wheels.Enums;

namespace Prestige_Wheels.Models.Cars
{
    public class CreateCarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public CarType CarType { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }


        [ValidateNever]
        public MultiSelectList CarTypeMultiSelectList { get; set; }

    }
}