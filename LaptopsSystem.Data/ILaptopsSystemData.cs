using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using LaptopsSystem.Models;

namespace LaptopsSystem.Data
{
    public interface ILaptopsSystemData
    {
        IRepository<Manufacturer> Manufacturers { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Laptop> Laptops { get; }
        IRepository<Vote> Votes { get; }
        IRepository<MonitorSize> MonitorSizes { get; }
        IRepository<User> Users { get; }
        IRepository<IdentityRole> Roles { get; }
        DbContext Context { get; }
        void Dispose();
        int SaveChanges();
    }
}
