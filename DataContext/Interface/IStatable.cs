using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Interface
{
    public interface IStatable
    {
        bool IsActive { get; set; }
        //bool IsDeleted { get; set; }
    }
}
