namespace Model.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        public long Bill_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Discount_ID { get; set; }

        public long TB_ID { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual TB_Information TB_Information { get; set; }
    }
}
