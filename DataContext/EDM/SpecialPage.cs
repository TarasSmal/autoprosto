namespace DataContext.EDM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SpecialPage
    {
        public SpecialPage()
        {
            CreatedOn = DateTime.Now;
        }
        public long Id { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }
        [StringLength(256)]
        public string PageImage { get; set; }

        public string Content { get; set; }

        [StringLength(150)]
        public string SEOTitle { get; set; }

        [StringLength(150)]
        public string SEODescription { get; set; }

        [StringLength(150)]
        public string KeyWord { get; set; }

        public int? PageId { get; set; }

        public bool IsActive { get; set; }

        public long IdUpdatedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedOn { get; set; }
        public int OriginalId { get; set; }
        public int IdLanguage { get; set; }
    }
}
