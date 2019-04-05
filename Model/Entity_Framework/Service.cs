namespace Model.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        [Key]
        public short Service_ID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(255)]
        public string Images { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
