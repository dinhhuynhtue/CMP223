namespace Model.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Table_ID { get; set; }

        public long? TB_ID { get; set; }

        public byte Seats { get; set; }

        public bool Status { get; set; }

        public virtual TB_Information TB_Information { get; set; }
    }
}
