using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SShou.Web.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly Users.IUserAppService userAppService;
        public UserLoginController(Users.IUserAppService _userAppService)
        {
            userAppService = _userAppService;
        }

        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(Users.Dto.UserLoginInputDto input)
        {
            Common.JsonResultStatus resJson = new Common.JsonResultStatus();

            var user = userAppService.LoginIn(input);
            if (user != null)
            {
                //string pwd = new PasswordHasher().HashPassword(input.PassWord);
                //if (user.PassWord != pwd)
                //{
                //    resJson.Code = 201;
                //    resJson.Msg = "密码错误";
                //}
                //else
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
       1,
       "admin",
       DateTime.Now,
       DateTime.Now.Add(FormsAuthentication.Timeout), true, string.Format("{0}", user.UserName)

       );

                    //DateTime.Now.Add(FormsAuthentication.Timeout), true, string.Format("{0}|{1}|{2}|{3}|{4}", user.Id, user.PhoneNo, user.NickName, accessToken, openId)
                    HttpCookie cookie = new HttpCookie(
                        Common.CommonConst.AuthSaveKey,
                        FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);
                    resJson.Code = 200;
                    resJson.Msg = "登录成功";
                }
            }
            else
            {
                resJson.Code = 202;
                resJson.Msg = "用户不存在";
            }
            return Json(resJson);
        }
    }
}