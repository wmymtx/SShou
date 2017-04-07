using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    public class RegisterWeChatController : Controller
    {
        private readonly WeUser.IWeUserAppService weUserAppService;
        public RegisterWeChatController(WeUser.IWeUserAppService _userAppService)
        {
            this.weUserAppService = _userAppService;
        }
        // GET: RegisterWeChat
        public ActionResult Index(Models.WeUserInfo weUserInfo)
        {
            if (weUserInfo == null || string.IsNullOrEmpty(weUserInfo.openId))
            {
                weUserInfo = new Models.WeUserInfo();
                weUserInfo.HeadImgUrl = "http://wx.qlogo.cn/mmopen/HtEJHGuES1WyonHaXDQRxe9iaKS8kIelY6WOOCibZOzrjInMOcZZP6kr5R5cH54NicJguZaqzz32Eic9Kyz8VpT0zA/0";
                weUserInfo.NickName = "與夢同荇";
                weUserInfo.openId = "oCbECv1pwMNyAodYQtRJVvJf_Zsg";
            }
            ViewBag.HeadImgUrl = weUserInfo.HeadImgUrl;
            ViewBag.NickName = weUserInfo.NickName;
            ViewBag.OpenId = weUserInfo.openId;
            ViewBag.retUrl = weUserInfo.retUrl;
            return View();
        }

        public JsonResult RegisterUser(WeUser.Dto.WeUserInputDto inputDto)
        {
            Common.JsonResultStatus jsonResult = new Common.JsonResultStatus();
            jsonResult.Code = 400;
            jsonResult.Msg = "注册失败";
            if (inputDto != null)
            {
                inputDto.RegDate = DateTime.Now;
                //WeUser.Dto.WeUserOutputDto outputDto = this.weUserAppService.GetWeUserByUserId(Common.UserHelper.Instance.getUserId());
                inputDto.Id = Common.UserHelper.Instance.getUserId();
                inputDto.IsInit = 0;

                if (this.weUserAppService.IsHasRecommendCode(inputDto.Recommend_Code))
                {
                    inputDto.Invit_Code = RandomNum(0);
                    this.weUserAppService.UpdateUser(inputDto);
                    if (inputDto != null)
                    {
                        jsonResult.Code = 200;
                        jsonResult.Msg = "注册成功";
                        jsonResult.Result = inputDto;
                        return Json(jsonResult);
                    }
                }
                else
                {
                    jsonResult.Code = 201;
                    jsonResult.Msg = "推荐码不存在！！！";
                    jsonResult.Result = inputDto;
                    return Json(jsonResult);
                }

            }
            return Json(jsonResult);
        }

        public JsonResult AlterUser(WeUser.Dto.WeUserInputDto inputDto)
        {
            Common.JsonResultStatus jsonResult = new Common.JsonResultStatus();
            jsonResult.Code = 400;
            jsonResult.Msg = "编辑失败";
            if (inputDto != null)
            {
                inputDto.RegDate = DateTime.Now;
                //WeUser.Dto.WeUserOutputDto outputDto = this.weUserAppService.GetWeUserByUserId(Common.UserHelper.Instance.getUserId());
                inputDto.Id = Common.UserHelper.Instance.getUserId();
                inputDto.IsInit = 0;

                this.weUserAppService.UpdateUser(inputDto);
                if (inputDto != null)
                {
                    jsonResult.Code = 200;
                    jsonResult.Msg = "编辑成功";
                    jsonResult.Result = inputDto;
                    return Json(jsonResult);
                }

            }
            return Json(jsonResult);
        }

        private int RandomNum(int isLoop)
        {
            int code = Common.RandomHelper.GetRandom(100000, 999999, 1)[0];
            if (weUserAppService.IsHasInvitCode(code))
            {
                return code;
            }
            else
            {
                return RandomNum(code);
            }
        }
    }
}