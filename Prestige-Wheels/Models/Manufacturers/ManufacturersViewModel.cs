

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Prestige_Wheels.Data.Entities;

namespace Prestige_Wheels.Models.Manufacturers
{
    public class ManufacturersViewModel
    {   
        
            public int Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }

            [ValidateNever]
            public List<Car> Cars { get; set; }
        
    }
}