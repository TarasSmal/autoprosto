namespace DataContext.EDM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        [Key]
        public long Id { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        public string Values { get; set; }
        public bool IsActive { get; set; }

        public long IdUpdatedBy { get; set; }

        public void Update(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
