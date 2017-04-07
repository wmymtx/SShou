using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace SShou.Web.Controllers
{
    //[AbpMvcAuthorize]
    //[Common.Authorization]
    [Authorize]
    public class HomeController : SShouControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}