using DataContext.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMachanics.Models
{
    public class ResponsesViewModel
    {
       public SpecialPage SpecialPages { get; set; }
        public int PageId = 4;
       public List<Respons> Responses { get; set; }
    }
}