﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    [Common.Authorization]
    public class UserController : Controller
    {
        // GET: User


        private Product.IProductAppService _prodAppService;
        public UserController(Product.IProductAppService _iProdAppService)
        {
            this._prodAppService = _iProdAppService;
        }

        public ActionResult Index(int type)
        {
            ViewBag.productList = this._prodAppService.GetProduct(type);
            ViewBag.OrderType = type;
            return View();
        }
    }
}