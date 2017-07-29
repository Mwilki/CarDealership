using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarDealershipEntities : IdentityDbContext<AppUser>
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<Make> VehicleMakers { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

        public DbSet<Model> VehicleModels { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public CarDealershipEntities() : base("CarDealership")
        {

        }
    }
}
