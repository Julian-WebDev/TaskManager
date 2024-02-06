using System.Web;
using System.Web.Mvc;

namespace TaskManager
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Add login filter
            filters.Add(new Filters.Session());
        }
    }
}
