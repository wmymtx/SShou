using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Senparc.Weixin.MP.Containers;

namespace SShou.Web
{
    public class MvcApplication : AbpWebApplication<SShouWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );
            AccessTokenContainer.Register(Common.CommonConst.AppID, Common.CommonConst.AppSecret);
            base.Application_Start(sender, e);
        }
    }
}
