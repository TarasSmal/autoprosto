using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.EDM
{
    public partial class Photo
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public long IdSlider { get; set; }
        public bool IsActive { get; set; }

        public long IdUpdatedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get; set; }

    }
}
