using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

using Microsoft.AspNet.Identity.EntityFramework;

using LaptopsSystem.Models;

namespace LaptopsSystem.Data
{
    public class LaptopsSystemDbContext : IdentityDbContext<User>
    {
        public LaptopsSystemDbContext()
            : base("LaptopsSystem", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Laptop> Laptops { get; set; }

        public IDbSet<MonitorSize> MonitorSizes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public static LaptopsSystemDbContext Create()
        {
            return new LaptopsSystemDbContext();
        }


        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var currentResult = base.ValidateEntity(entityEntry, items);
            if (entityEntry.State == EntityState.Modified)
            {
                var errors = currentResult.ValidationErrors;
                if (errors.Count > 0)
                {
                    List<DbValidationError> result = new List<DbValidationError>();
                    foreach (var error in errors)
                    {
                        string propName = error.PropertyName;
                        if (entityEntry.Property(propName).IsModified)
                        {
                            result.Add(error);
                        }
                    }
                    return new DbEntityValidationResult(entityEntry, result);
                }
            }
            return currentResult;
        }
    }
}
