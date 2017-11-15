namespace DataContext.EDM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EasyMechanicsEDM : DbContext
    {
        public EasyMechanicsEDM()
            : base("name=EasyMechanicsEDM")
        {
        }

        
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<SpecialPage> SpecialPages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Respons> Responses { get; set; }
        public virtual DbSet<Slider> Sliders{ get; set; }
        public virtual DbSet<FileBank> FileBanks { get; set; }
        public virtual DbSet<Photo> Photos{ get; set; }
    }
}
