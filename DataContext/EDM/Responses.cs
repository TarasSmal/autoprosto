using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace DataContext.EDM
{
    public partial class Respons
     {
        public long Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public long IdUpdatedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get; set; }
    }
}
