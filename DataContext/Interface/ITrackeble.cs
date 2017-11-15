using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Interface
{
   public interface ITrackeble
    {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
        long IdUpdatedBy { get; set; }
    }
}
