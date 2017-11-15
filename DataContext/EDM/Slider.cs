using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.EDM
{
    public partial class Slider
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? PageId { get; set; }
        public string Image { get; set; }

        public long IdUpdatedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get; set; }
        public int OriginalId { get; set; }
        public int IdLanguage { get; set; }
        public string Description { get; set; }
    }
}
