using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SShou.Web.Controllers
{
    [Common.Authorization]
    public class UserAddressController : Controller
    {
        private readonly UserAddress.IUserAddressAppService _userAddressAppService;

        public UserAddressController(UserAddress.IUserAddressAppService userAddressAppService)
        {
            this._userAddressAppService = userAddressAppService;
        }

        // GET: UserAddress
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public JsonResult getAll()
        {
            var data = _userAddressAppService.GetAllAddress(Common.UserHelper.Instance.getUserId());
            //var data = _userAddressAppService.GetAllAddress(5);
            Common.JsonResultStatus rst = new Common.JsonResultStatus() { Code = 200, Msg = "获取成功", Result = data };
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDetailById(int addrId)
        {
            var data = _userAddressAppService.GetAddress(addrId);
            Common.JsonResultStatus rst = new Common.JsonResultStatus() { Code = 200, Msg = "获取成功", Result = data };
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditAddress(UserAddress.Dto.UserAddressInputDto input)
        {
            Common.JsonResultStatus rst = new Common.JsonResultStatus();
            try
            {
                input.UserId = Common.UserHelper.Instance.getUserId();
                _userAddressAppService.UpdateAddress(input);
                rst.Code = 200;
                rst.Msg = "修改成功";
                return Json(rst);
            }
            catch (Exception ex)
            {
                rst.Code = 500;
                rst.Msg = ex.Message;
                return Json(rst);
            }
        }

        [HttpPost]
        public JsonResult AddNewAddress(UserAddress.Dto.UserAddressInputDto input)
        {
            Common.JsonResultStatus rst = new Common.JsonResultStatus();
            try
            {
                input.UserId = Common.UserHelper.Instance.getUserId();
                _userAddressAppService.AddNewAddress(input);
                rst.Code = 200;
                rst.Msg = "添加成功";
                return Json(rst);
            }
            catch (Exception ex)
            {
                rst.Code = 500;
                rst.Msg = ex.Message;
                return Json(rst);
            }
        }

        [HttpPost]
        public JsonResult SetDefault(UserAddress.Dto.UserAddressInputDto input)
        {
            input.UserId = Common.UserHelper.Instance.getUserId();
            Common.JsonResultStatus rst = new Common.JsonResultStatus();
            try
            {
                _userAddressAppService.SetDefault(input);
                rst.Code = 200;
                rst.Msg = "修改成功";
                return Json(rst);
            }
            catch (Exception ex)
            {
                rst.Code = 500;
                rst.Msg = ex.Message;
                return Json(rst);
            }

        }

        public JsonResult RemoveAddress(int id)
        {

            Common.JsonResultStatus rst = new Common.JsonResultStatus();
            try
            {
                _userAddressAppService.RemoveAddress(id);
                rst.Code = 200;
                rst.Msg = "修改成功";
                return Json(rst);
            }
            catch (Exception ex)
            {
                rst.Code = 500;
                rst.Msg = ex.Message;
                return Json(rst);
            }

        }
    }
}