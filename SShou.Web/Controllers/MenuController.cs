using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    public class MenuController : SShouControllerBase
    {
        // GET: Menu
        public ActionResult Index()
        {
            var accessToken = AccessTokenContainer.GetAccessToken(Common.CommonConst.AppID);

            ButtonGroup bg = new ButtonGroup();

            ////单击
            //bg.button.Add(new SingleClickButton()
            //{
            //    name = "废品回收",
            //    key = "OneClick",
            //    type = ButtonType.click.ToString(),//默认已经设为此类型，这里只作为演示
            //});
            ////单击
            //bg.button.Add(new SingleClickButton()
            //{
            //    name = "废品回收",
            //    key = "OneClick",
            //    type = ButtonType.click.ToString(),//默认已经设为此类型，这里只作为演示
            //});
            ////单击
            //bg.button.Add(new SingleClickButton()
            //{
            //    name = "废品回收",
            //    key = "OneClick",
            //    type = ButtonType.click.ToString(),//默认已经设为此类型，这里只作为演示
            //});

            //二级菜单
            var subButton = new SubButton()
            {
                name = "废品回收"
            };
            subButton.sub_button.Add(new SingleViewButton()
            {
                name = "关于收收",
                url = "http://weixin.shoushouto.com/about.html"
            });
            subButton.sub_button.Add(new SingleViewButton()
            {
                
                name = "企业下单",
                  url= "http://weixin.shoushouto.com/User/Index?type=2"
            });
            subButton.sub_button.Add(new SingleViewButton()
            {
               
                name = "个人下单",
                 url= "http://weixin.shoushouto.com/User/Index?type=1"

            });

            //二级菜单
            var subSecButton = new SubButton()
            {
                name = "回收加盟"
            };

            subSecButton.sub_button.Add(new SingleViewButton() {
                 name= "加入收收",
                  url= "http://weixin.shoushouto.com/SS_WeiUser/Index"
            });

            var subTheButton = new SubButton()
            {
                name = "我的收收"
            };

            subTheButton.sub_button.Add(new SingleViewButton()
            {
                name = "我的订单",
                url = "http://weixin.shoushouto.com/Order/History"
            });

            subTheButton.sub_button.Add(new SingleViewButton() {
                name = "我的资料",
                url = "http://weixin.shoushouto.com/UserProfile/Index"
            });

            subTheButton.sub_button.Add(new SingleViewButton() {
                 name="我的推荐",
                  url= "http://weixin.shoushouto.com/Poster/Index"
            });

            bg.button.Add(subButton);
            bg.button.Add(subSecButton);
            bg.button.Add(subTheButton);

            var result = CommonApi.CreateMenu(accessToken, bg);

            //获取菜单
            //var result = CommonApi.GetMenu(accessToken);
            //删除菜单
            //var result = CommonApi.DeleteMenu(accessToken);
            return View();
        }
    }
}