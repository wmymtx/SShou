using Abp.Web.Mvc.Views;

namespace SShou.Web.Views
{
    public abstract class SShouWebViewPageBase : SShouWebViewPageBase<dynamic>
    {

    }

    public abstract class SShouWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SShouWebViewPageBase()
        {
            LocalizationSourceName = SShouConsts.LocalizationSourceName;
        }
    }
}