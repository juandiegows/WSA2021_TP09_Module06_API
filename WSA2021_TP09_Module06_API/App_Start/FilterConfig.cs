using System.Web;
using System.Web.Mvc;

namespace WSA2021_TP09_Module06_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
