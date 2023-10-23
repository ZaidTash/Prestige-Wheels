using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Prestige_Wheels.Data.Entities;

namespace Prestige_Wheels.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }
            public DbSet<Car> Cars { get; set; }
            public DbSet<Manufacturer> Manufacturers { get; set; }  
    }
    }

