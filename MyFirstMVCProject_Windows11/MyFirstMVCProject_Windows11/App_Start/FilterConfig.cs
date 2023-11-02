using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCProject_Windows11
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
