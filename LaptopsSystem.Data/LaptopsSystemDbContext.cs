using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using LaptopsSystem.Models;

namespace LaptopsSystem.Data
{
    public class LaptopsSystemDbContext : IdentityDbContext<User>
    {
        public LaptopsSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Laptop> Laptops { get; set; }

        public IDbSet<MonitorSize> MonitorSizes { get; set; }

        public IDbSet<Commment> Comments { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static LaptopsSystemDbContext Create()
        {
            return new LaptopsSystemDbContext();
        }
    }
}
