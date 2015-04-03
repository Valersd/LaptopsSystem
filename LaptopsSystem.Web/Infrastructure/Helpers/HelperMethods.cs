using System;
using System.Web;

namespace LaptopsSystem.Web.Infrastructure.Helpers
{
    public static class HelperMethods
    {
        public static DateTime ToClientTime(this DateTime dt)
        {
            // read the value from session
            var timeOffSet = HttpContext.Current.Session["timezoneoffset"];

            if (timeOffSet != null)
            {
                var offset = int.Parse(timeOffSet.ToString());
                dt = dt.AddMinutes(-1 * offset);

                return dt;
            }

            // if there is no offset in session return the datetime in server timezone
            return dt.ToLocalTime();
        }
    }
}