using System;
using System.Collections.Generic;

using LaptopsSystem.Web.ViewModels;

namespace LaptopsSystem.Web.Infrastructure.Cache
{
    public interface ICacheService
    {
        IList<LaptopIndex> Laptops { get; }
    }
}
