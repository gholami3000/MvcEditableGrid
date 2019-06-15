namespace MvcEditableGrid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoir_ho.tblBook")]
    public partial class tblBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBook()
        {
            tblBookReserve = new HashSet<tblBookReserve>();
        }

        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBookReserve> tblBookReserve { get; set; }

        //public List<tblBookReserve> ReserveList { get; set; }


    }
}
