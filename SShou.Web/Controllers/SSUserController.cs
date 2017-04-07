﻿using Abp.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    [Authorize]
    public class SSUserController : Controller
    {

        private readonly SS_User.ISs_UserAppService userAppService;
        public SSUserController(Orders.IOrderAppService _orderAppService, SS_User.ISs_UserAppService _userAppService)
        {
            userAppService = _userAppService;
        }
        // GET: SSUser
        public ActionResult Index()
        {
            ViewBag.User = userAppService.GetAllUser();
            return View();
        }

        public JsonResult  GetOrderList(int limit, int offset, string departmentname, int status, string orderTime)
        {

            var rst = new { rows = userAppService.GetUserByPage(offset, limit, status), total = userAppService.GetTotal(status) };
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(int userId)
        {
            var item= userAppService.GetUserDetail(userId);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditStatus(int userId, int status)
        {
            Common.JsonResultStatus json = new Common.JsonResultStatus();
            json.Code = 200;
            if (userAppService.UpdateStatus(userId, status) > 0)
            {
                json.Msg = "操作成功";
            }
            else
            {
                json.Msg = "操作失败";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}