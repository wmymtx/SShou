using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    [Common.Authorization]
    public class UserProfileController : Controller
    {
        private readonly WeUser.IWeUserAppService userAppService;

        private readonly UserPoints.IUserPointAppService userPointsAppService;

        public UserProfileController(WeUser.IWeUserAppService _userAppService, UserPoints.IUserPointAppService _userPointsAppService)
        {
            this.userAppService = _userAppService;
            this.userPointsAppService = _userPointsAppService;
        }
        // GET: UserProfile
        public ActionResult Index()
        {
            int userId = Common.UserHelper.Instance.getUserId();
            WeUser.Dto.WeUserOutputDto user = userAppService.GetWeUserByUserId(userId);
            if (user == null)
            {
                user = new WeUser.Dto.WeUserOutputDto();
            }
            ViewBag.HeadImgUrl = user.HeadImgUrl;
            ViewBag.NickName = user.NickName;
            ViewBag.PhoneNo = user.PhoneNo;
            ViewBag.Recommend_Code = user.Recommend_Code;
            ViewBag.Invit_Code = user.Invit_Code;
            ViewBag.PointScore = userPointsAppService.GetPointScore(userId);
            return View();
        }

        [HttpPost]
        public JsonResult SignValidate()
        {
            UserPoints.Dto.UserPointsInputDto input = new UserPoints.Dto.UserPointsInputDto();
            input.Score = int.Parse(Common.CommonConst.PointsScore);
            input.UserId = Common.UserHelper.Instance.getUserId();
            Common.JsonResultStatus json = new Common.JsonResultStatus();
            json.Code = 0;
            if (userPointsAppService.SignPoints(input) > 0)
            {
                json.Code = 1;
                json.Result = Common.CommonConst.PointsScore;
                json.Msg = "已签到";
            }
            else
            {
                json.Msg = "签到失败";
            }
            return Json(json);
        }
        [HttpPost]
        public JsonResult SearchStatus()
        {
            Common.JsonResultStatus json = new Common.JsonResultStatus();
            json.Code = 0;
            json.Msg = "未签到";
            if (userPointsAppService.IsSign(Common.UserHelper.Instance.getUserId()) > 0)
            {
                json.Code = 1;
                json.Msg = "已签到";
            }
            return Json(json);

        }

        public ActionResult AlterUserInfo()
        {
            var user = userAppService.GetWeUserByUserId(Common.UserHelper.Instance.getUserId());
            if (user != null)
            {
                ViewBag.UserInfo = user;
            }
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}