using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopsSystem.Web.Infrastructure.ModelBinders
{
    public class DecimalAndDoubleModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object result = null;
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null)
            {
                string valueResult = value.AttemptedValue.Trim();
                if (String.IsNullOrEmpty(valueResult))
                {
                    return base.BindModel(controllerContext, bindingContext);
                }
                string wantedSeperator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                string alternateSeperator = (wantedSeperator == "," ? "." : ",");

                if (valueResult.IndexOf(wantedSeperator) == -1
                  && valueResult.IndexOf(alternateSeperator) != -1)
                {
                    valueResult = valueResult.Replace(alternateSeperator, wantedSeperator);
                }
                try
                {
                    if (bindingContext.ModelType == typeof(double) || bindingContext.ModelType == typeof(double?))
                    {
                        result = double.Parse(valueResult);
                    }
                    else if (bindingContext.ModelType == typeof(decimal) || bindingContext.ModelType == typeof(decimal?))
                    {
                        result = decimal.Parse(valueResult);
                    }
                }
                catch (Exception ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
                }
                return result;
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}