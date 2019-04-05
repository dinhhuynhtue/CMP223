namespace Model.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public DateTime datebegin;

        [Key]
        public long Feedback_ID { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }
    }
}
