using DataContext.Interface;
using DataContext.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DataContext.EDM
{
    public partial class FileBank : Repository<FileBank, int>, ITrackeble, IStatable, IPrimary<int>
    {
     
    }
}
