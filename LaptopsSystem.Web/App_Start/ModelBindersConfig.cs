using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LaptopsSystem.Web.Infrastructure.ModelBinders;

namespace LaptopsSystem.Web.App_Start
{
    public static class ModelBindersConfig
    {
        public static void RegisterBindings()
        {
            ModelBinders.Binders.Add(typeof(decimal), new DecimalAndDoubleModelBinder());
            ModelBinders.Binders.Add(typeof(double), new DecimalAndDoubleModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalAndDoubleModelBinder());
            ModelBinders.Binders.Add(typeof(double?), new DecimalAndDoubleModelBinder());
        }
    }
}