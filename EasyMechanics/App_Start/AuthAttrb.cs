using DataContext.Authorization;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Authorization
{
    public class AuthenticateAttribute : AuthorizeAttribute
    {

        public bool AllowAnonymus { get; set; }

        public AuthenticateAttribute() { }

        protected override bool AuthorizeCore(HttpContextBase httpContext)  //вирішуємо чи даит доступ
        {
            if (AllowAnonymus)
                return true;
            if (FormsAuthenticationService.User != null)
                if (string.IsNullOrEmpty(Roles) || base.Roles == null)
                    return true;
                else
                    return FormsAuthenticationService.User.IsInRole(base.Roles);
            return false;
        }

        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.Result = new System.Web.Mvc.RedirectResult("/Account/Login/?ReturnUrl=" + filterContext.HttpContext.Request.Url.AbsolutePath);
        }
    }
}