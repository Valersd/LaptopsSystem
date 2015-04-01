using System;
using System.Collections.Generic;
using System.Web.Mvc;

using LaptopsSystem.Web.ViewModels;

namespace LaptopsSystem.Web.Infrastructure.Cache
{
    public interface ICacheService
    {
        IList<LaptopIndex> Laptops { get; }
        IEnumerable<SelectListItem> Manufacturers { get; }
        IEnumerable<SelectListItem> MonitorSizes { get; }
        void Remove(string key);
    }
}
