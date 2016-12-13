using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    public class AboutController : SShouControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}