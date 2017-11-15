namespace DataContext.EDM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {


        public long Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Email { get; set; }
        public int IdRole { get; set; }

        [StringLength(512)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public long IdUpdatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        [StringLength(32)]
        public string Phone { get; set; }

    }
}
