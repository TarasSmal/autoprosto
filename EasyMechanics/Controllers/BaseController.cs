using DataContext.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Controllers
{
    [Defend]
    public class BaseController : Controller
	{
		public static string CurrentLang { get; protected set; }
        readonly string ckookiesName = "_cultureEasyMechanics";

		/// <summary>
		///returns 
		/// </summary>
		public static int IdCurrentLang
		{
			get
			{
				return (int)Enum.Parse(typeof(Languages), CurrentLang);
			}
		}

		
		//public static DataManager DataManager = new DataManager();

		protected override void Initialize(System.Web.Routing.RequestContext requestContext)
		{
			CurrentLang = "uk";

			try
			{
				//робимо мову за замовчуванням
				//також її треба поставити в роут конфігах
				CurrentLang = requestContext.HttpContext.Request.UserLanguages[1].Remove(2);    // питамо яка культура в браузера
																								//ставимо за замовчування значення яке прийшло до нас від браузера, якшо воно 
				if (CurrentLang != "ru" && CurrentLang != "uk" )
					CurrentLang = "uk";
			}
			catch
			{
				CurrentLang = "uk"; //якщо шось не то тоді, мова укр
			}

			//питаємо чи прийшла якась мова з роута(то б мало значати, шо юзер клікнув її помініяти)
			if (requestContext.RouteData.Values["lang"] != null)
			{
				//ставимо ту мову шо вибрав юзер
				CurrentLang = requestContext.RouteData.Values["lang"] as string;

				//запивуємо нову мову в кукі
				HttpCookie cookie = requestContext.HttpContext.Request.Cookies[ckookiesName];
				//якщо кукі є, то обновлюємо дані
				if (cookie != null)
					cookie.Value = CurrentLang;   // update cookie value
				else
				{
					//інакше треба створити кукі
					cookie = new HttpCookie(ckookiesName);
					cookie.Value = CurrentLang;
					cookie.Expires = DateTime.Now.AddMonths(1);
				}
				requestContext.HttpContext.Response.Cookies.Add(cookie);
			}

			// читаємо кукі
			HttpCookie cultureCookie = requestContext.HttpContext.Request.Cookies[ckookiesName];
			if (cultureCookie != null)  //якшо є то ставимо ту мову яка в кукісах
				CurrentLang = cultureCookie.Value;

			//ставимо значення мови!!!
			SetCulture(CurrentLang);
			base.Initialize(requestContext);
		}

		//мутня з культурами. задаємо їх для сайту!
		private void SetCulture(string CurrentLang)
		{
			var ci = new CultureInfo(CurrentLang);
			Thread.CurrentThread.CurrentUICulture = ci;
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
		}
	}
}