namespace Model.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dish")]
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            TB_Detail = new HashSet<TB_Detail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Dish_ID { get; set; }

        public short Type_ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public float? Price { get; set; }

        [StringLength(255)]
        public string Detail { get; set; }

        [Column(TypeName = "text")]
        public string Images { get; set; }

        public virtual FoodType FoodType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Detail> TB_Detail { get; set; }
    }
}