using System.Web;
using System.Web.Mvc;

namespace com.hit.webapi.driverandtruck.status
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
