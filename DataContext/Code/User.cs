using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext.Repository;
using DataContext.Enums;
using System.Data;
using System.Net;
using System.Xml;
using System.Web;
using Newtonsoft.Json;
using System.Globalization;
using DataContext.Interface;
using System.Security.Claims;
using DataContext.Authorization;

namespace DataContext.EDM
{
    public partial class User : Repository<User, long>, ITrackeble, IStatable, IPrimary<long>
    {

        //public User()
        //{
        //    this.Location = GetUserCountryByIp();
        //}

       public static User GetOne(string Email, string Hash)
        {
            using (var dm = new DataContextProvider())
            {
                return dm.Users.FirstOrDefault(f => f.Email == Email && f.Password == Hash);
            }
        }

        public static DataTable GetLocation(string ipaddress)
        {
            WebRequest rssReq = WebRequest.Create("http://freegeoip.appspot.com/xml/" + ipaddress);
            WebProxy px = new WebProxy("http://freegeoip.appspot.com/xml/" + ipaddress, true);
            rssReq.Proxy = px;
            rssReq.Timeout = 2000;
            try
            {
                WebResponse rep = rssReq.GetResponse();
                XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
                DataSet ds = new DataSet();
                ds.ReadXml(xtr);
                return ds.Tables[0];
            }
            catch(Exception ex)
            {
                
                return null;
            }
        }

         string GetUser_IP()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }
        
        public  ClaimsIdentity GetClaims()
        {
            var claimses = new List<Claim>();
            claimses.Add(new Claim(ClaimTypes.Name, Name));
            claimses.Add(new Claim(ClaimTypes.Email, Email));
            claimses.Add(new Claim(ClaimTypes.Hash, Password));
            claimses.Add(new Claim(ClaimTypes.Role, "Admin"));

            var Claims = new ClaimsIdentity(claimses, "ApplicationCookie");

            return Claims;
        }

        /// <summary>
        /// Перевіряє, чи роль авторищованого користувача дорівнює заданій
        /// </summary>
        /// <param name="Roles">назва ролі</param>
        /// <returns></returns>
        public bool IsInRole(string Roles)  //roles checking
        {
            if ((int)Enum.Parse(typeof(Roles), Roles) == FormsAuthenticationService.User.IdRole)
                return true;

            return false;
        }

        public static void UpdatePassword(long id, string v)
        {
            throw new NotImplementedException();
        }
    }
}
