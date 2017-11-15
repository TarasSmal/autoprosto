using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics
{
    public class DefendAttribute : ActionFilterAttribute
    {
		DateTime DeadDay = new DateTime(2017,12,10);
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //якщо дата виходить за задану то ми редаректимо на наш сайт)
				if (DateTime.Now >= DeadDay)

            //тут треба вказати домен на якому має працювати сайт, тільки його
            // || !filterContext.RequestContext.HttpContext.Request.Url.OriginalString.ToString().Contains("localhost:32669"))
            {
                //робимо редірект
                filterContext.RequestContext.HttpContext.Response.Redirect("https://www.google.com");
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            ;
        }
    }
}