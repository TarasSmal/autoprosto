using System.Web.Mvc;

namespace EasyMachanics.Areas.ControlPanel
{
    public class ControlPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName
        {
            get
            {
                return "ControlPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ControlPanel_default",
                "ControlPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                          "ControlPanel",
                          "ControlPanel/{controller}/{action}/{id}",
                          new { controller = "Dashbord", action = "Index", id = UrlParameter.Optional },
                          new[] { "EasyMachanics.Areas.ControlPanel.Controllers" }
                       );
        }
    }
}