using System.Web;
using System.Web.Mvc;

namespace Linq_CRUD_teachers_students
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
