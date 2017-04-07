using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        private readonly WeUser.IWeUserAppService userAppService;

        public InfoController(WeUser.IWeUserAppService _userAppService)
        {
            userAppService = _userAppService;
        }
        public ActionResult Index()
        {
            var hasUser = userAppService.IsInit(Common.UserHelper.Instance.getUserId());
            if (null != hasUser && hasUser.IsInit == 0)
            {
                ViewBag.IsInit = "none";
            }
            else
            {
                ViewBag.IsInit = "block";
                ViewBag.Url = string.Format("/RegisterWeChat/Index?openId={0}&HeadImgUrl={1}&NickName={2}&retUrl={3}", hasUser.OpenId, hasUser.HeadImgUrl, hasUser.NickName, "/Info/Index");
            }
            return View();
        }
    }
}