using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;

using AutoMapper.QueryableExtensions;

using LaptopsSystem.Web.ViewModels;
using LaptopsSystem.Data;

namespace LaptopsSystem.Web.Infrastructure.Cache
{
    public class CacheService : BaseCacheService, ICacheService
    {
        private ILaptopsSystemData _data;

        public CacheService(ILaptopsSystemData data)
        {
            _data = data;
        }

        public IList<LaptopIndex> Laptops
        {
            get
            {
                return this.Get("Laptops",
                    () => _data.Laptops
                            .All()
                            .Include(l => l.Manufacturer)
                            .Include(l => l.Votes)
                            .OrderByDescending(l => l.Votes.Count)
                            .Take(6)
                            .Project()
                            .To<LaptopIndex>()
                            .ToList()
                            , 60*60);
            }
        }

        public IEnumerable<SelectListItem> Manufacturers
        {
            get 
            {
                var items = this.Get("Manufacturers",
                    () => _data.Manufacturers.All().OrderBy(m => m.Name).ToList(), 60 * 60);
                return items.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });
            }
        }
    }
}