using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    public class SS_WeiUserController : Controller
    {
        private readonly SS_User.ISs_UserAppService _userAppService;
        private readonly string AppID = Common.CommonConst.AppID;
        private readonly string AppSecret = Common.CommonConst.AppSecret;
        private readonly SsCategory.ISsCategoryAppService _categoryAppService;

        public SS_WeiUserController(SS_User.ISs_UserAppService userAppService, SsCategory.ISsCategoryAppService categoryAppService)
        {
            this._userAppService = userAppService;
            this._categoryAppService = categoryAppService;
        }
        // GET: SS_WeiUser
        public ActionResult Index()
        {
            string code = Request.QueryString["code"] ?? "";
            string retUrl = Request.QueryString["retUrl"] ?? "";

            #region pc测试注释

            ////微信用户信息授权
            string openurl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect", AppID, "http://weixin.shoushouto.com/SS_WeiUser/Index");
            if (string.IsNullOrWhiteSpace(code))
            {
                Response.Redirect(openurl);
            }
            else
            {
                Dictionary<string, string> rst = new Dictionary<string, string>();
                try
                {
                    rst = Senparc.Weixin.HttpUtility.Get.GetJson<Dictionary<string, string>>(string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppID, AppSecret, code));
                }
                catch (Exception e)
                {

                }
                if (rst.Count >= 1)
                {
                    string accessToken;
                    if (!rst.TryGetValue("access_token", out accessToken))
                    { }
                    var opentid = rst["openid"];
                    var url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", accessToken, opentid);
                    var userInfo = Senparc.Weixin.HttpUtility.Get.GetJson<Models.WeiXinUserInfo>(url);
                    if (userInfo != null)
                    {
                        ViewBag.OpenId = opentid;
                        ViewBag.accessToken = accessToken;
                        ViewBag.retUrl = retUrl;
                        ViewBag.HeadImgUrl = userInfo.headimgurl;
                        ViewBag.NickName = userInfo.nickname;


                    }

                    #endregion
                    #region pc测试使用

                    //ViewBag.OpenId = "oCbECv1pwMNyAodYQtRJVvJf_Zsg";
                    //ViewBag.accessToken = "_HuO-csbnk2084EDPvhr2h0x2mwhB-mxYKXjFYMSG0P2ErgtdPBMPx0wIoO8qB9BWuO6ZFkL8U0XyEDB2hyLzxcx5Fjmm4ftCCEtpuzy92M";
                    //ViewBag.retUrl = "http://weixin.shoushouto.com/User/Index?type=1";
                    //ViewBag.HeadImgUrl = "http://wx.qlogo.cn/mmopen/HtEJHGuES1WyonHaXDQRxe9iaKS8kIelY6WOOCibZOzrjInMOcZZP6kr5R5cH54NicJguZaqzz32Eic9Kyz8VpT0zA/0";
                    //ViewBag.NickName = "aaa";
                    #endregion

                }
            }
            ViewBag.Category = _categoryAppService.GetAllCategory();
            return View();
        }

        public JsonResult Register(SS_User.Dto.SS_UserInputDto input)
        {
            Common.JsonResultStatus jsonStatus = new Common.JsonResultStatus();
            jsonStatus.Code = 200;
            if (string.IsNullOrWhiteSpace(input.OpenId))
            {
                jsonStatus.Msg = "未获取到OpenId";
            }
            else
            {
                int state = this._userAppService.CreateUser(input);
                if (state == 1)
                    jsonStatus.Msg = "已成功加入";
                else
                    jsonStatus.Msg = "已经加入过了";
            }
            return Json(jsonStatus);
        }
    }
}