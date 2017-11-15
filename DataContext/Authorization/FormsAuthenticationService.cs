using EncryptStringSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DataContext.EDM;


namespace DataContext.Authorization
{
    public class FormsAuthenticationService
    {
        public const string AuthCookieName = "EasyMechanicsdata";   //назва кукусів

        public static void Login(User user, bool rememberMe)
        {
            DateTime expiresDate = DateTime.Now.AddHours(13);
            if (rememberMe)
                expiresDate = expiresDate.AddMonths(1);
            SetValue(AuthCookieName, user.Email, expiresDate);
        }

        public static User User //повертаємо юзера якшо він залогінений через кукі, якшо ні то повертаємо null
        {
            get
            {

                User user = null;
                object cookie = HttpContext.Current.Request.Cookies[AuthCookieName] != null ? HttpContext.Current.Request.Cookies[AuthCookieName].Value : null;

                if (cookie != null && !string.IsNullOrEmpty(cookie.ToString()))
                {
                    try
                    {
                        //розшифровуємо кукі
                        string email = StringCipher.Decrypt(cookie.ToString());
                        user = User.GetAll().FirstOrDefault(u => u.Email == email);
                    }
                    catch
                    {
                        return user;
                    }
                }
                return user;
            }
        }

        public static void Logout() //виходимо
        {
            var cookies = new HttpCookie(AuthCookieName);
            cookies.Value = "Slava Ukraini ";
            cookies.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Current.Response.Cookies.Add(cookies);

        }
        //ставимо кукіси шуфруючи StringCipher.Encrypt(cookieObject)
        private static void SetValue(string cookieName, string cookieObject, DateTime dateStoreTo)
        {
            HttpCookie userCookie = new HttpCookie(AuthCookieName, StringCipher.Encrypt(cookieObject));
            userCookie.Expires = dateStoreTo;
            HttpContext.Current.Response.SetCookie(userCookie);
        }
    }
}