//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataContext.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileBank
    {
        public int Id { get; set; }
        public int IdType { get; set; }
        public string Note { get; set; }
        public string Path { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long IdUpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
