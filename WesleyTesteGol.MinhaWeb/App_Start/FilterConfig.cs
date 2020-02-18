using System.Web;
using System.Web.Mvc;

namespace WesleyTesteGol.MinhaWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
