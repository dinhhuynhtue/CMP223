namespace Model.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subcribe")]
    public partial class Subcribe
    {
        [Key]
        [StringLength(255)]
        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
