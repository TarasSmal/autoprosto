using DataContext.EDM;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            string cssClass = "active";
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

		/// <summary>
		/// Render special block
		/// </summary>
		/// <param name="html"></param>
		/// <param name="Id">Special block template ID</param>
		/// <returns></returns>
		//public static HtmlString RenderSpecialBlock(this HtmlHelper html, int Id)
		//{
		//	SpecialBlockTemplate specialBlockTemplate = SpecialBlockTemplate.GetOne(Id);

		//	var specialBlocks = SpecialBlockItem.GetAll(Id);

		//	//get all string propertis from object
		//	var props = typeof(SpecialBlockItem).GetProperties().Where(x => x.PropertyType.Name == "String").ToArray();



		//	StringBuilder result = new StringBuilder();
		//	result.Append(specialBlockTemplate.Header);

		//	foreach (object item in specialBlocks)
		//	{
		//		//crete a body which includes content of each special block
		//		StringBuilder body = new StringBuilder();
		//		body.Append(specialBlockTemplate.Content);
		//		foreach (var prop in props)
		//		{
		//			//get each property's value
		//			var value = prop.GetValue(item, null);
		//			if (value != null)
		//				//replace property's name on property's value
		//				body = body.Replace("@" + prop.Name, value.ToString());
		//		}
		//		result.Append(body);
		//	}



		//	result.Append(specialBlockTemplate.Footer);

		//	var content = new HtmlString(result.ToString());

		//	return content;

		//}

	}
}
