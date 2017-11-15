using DataContext.Interface;
using DataContext.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.EDM
{
   public partial class Photo: Repository<Photo, long>, ITrackeble, IStatable, IPrimary<long>
    {
    }
}
